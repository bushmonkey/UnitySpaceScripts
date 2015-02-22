using UnityEngine;
using System.Collections;

public class GetGoodies : MonoBehaviour {

	public GameObject explosion;
	public int scoreValue;
	public GameObject shotSpawnObject;
	public GameObject doubleShotControl1;
	public GameObject doubleShotControl2;
	public bool isUpgrade;
	public bool isMultiplier;

	private GameController gameController;
	private ShotControl shotControl;
	private ShotControl doubleShotControl1Component;
	private AssignGameController assignedGameController;
	private Vector3 shotSpawnLocation;
	private GameObject PlayerObject;

	void Start()
	{
		assignedGameController = GetComponent<AssignGameController> ();
		PlayerObject = GameObject.FindWithTag ("Player");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {

			Instantiate (explosion, transform.position,transform.rotation);
			Destroy (gameObject);
			if (isMultiplier)
			{
				assignedGameController.gamecontroller.IncreaseMultiplier();
			}
			if (isUpgrade)
			{
				shotSpawnLocation.x=PlayerObject.transform.position.x-0.66f;
				shotSpawnLocation.y=0.0f;
				shotSpawnLocation.z=PlayerObject.transform.position.z-0.2f;
				GameObject go =Instantiate(doubleShotControl1,shotSpawnLocation,Quaternion.identity) as GameObject; 
				go.transform.parent = PlayerObject.transform;
				doubleShotControl1Component = go.GetComponent <ShotControl> ();
				doubleShotControl1Component.SwitchSpawn(true);

				shotSpawnLocation.x=PlayerObject.transform.position.x+0.66f;
				shotSpawnLocation.y=0.0f;
				shotSpawnLocation.z=PlayerObject.transform.position.z-0.2f;
				go =Instantiate(doubleShotControl2,shotSpawnLocation,Quaternion.identity) as GameObject; 
				go.transform.parent = PlayerObject.transform;
				doubleShotControl1Component = go.GetComponent <ShotControl> ();
				doubleShotControl1Component.SwitchSpawn(true);
			}
			assignedGameController.gamecontroller.addScore(scoreValue);	
		}
	}
}
