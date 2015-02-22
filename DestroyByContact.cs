using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject PlayerExplosion;
	public GameObject EnemyExplosion;
	public GameObject ScoreCheck;
	public GameObject Goodies;
	public bool isInvincible;
	private GameController gameController;

	public int strength;
	public int scoreValue;
	public int GoodiesRandomness;

	private AssignGameController assignedGameController;
	private int ReceivedGoodies;
	private GameObject CanvasObject;

	// Use this for initialization
	void Start () {
		CanvasObject = GameObject.FindWithTag ("Canvas");
		assignedGameController = GetComponent<AssignGameController> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag=="Enemy")
		{
			return;
		}
		strength -= 1;
		if (other.tag == "Player" && !isInvincible) {
			Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation); 
			assignedGameController.gamecontroller.GameOver();
			Destroy (other.gameObject);
		} else if (other.tag != "Player") {
			Instantiate (explosion, other.transform.position, other.transform.rotation); 
			Destroy (other.gameObject);
		}
		if (strength < 1) {
			ReceivedGoodies=Random.Range(0,GoodiesRandomness);
			Debug.Log("random: " + ReceivedGoodies.ToString());
			Destroy (gameObject);
			GameObject go=Instantiate(ScoreCheck,transform.position,Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
			go.transform.parent = CanvasObject.transform;
			Instantiate(EnemyExplosion,transform.position,transform.rotation); 	
			if (ReceivedGoodies==1 && Goodies != null)
			{
				Instantiate(Goodies,transform.position,transform.rotation);
			}
			assignedGameController.gamecontroller.addScore(scoreValue);	
		}
	}
}
