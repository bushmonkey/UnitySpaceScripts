using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {
	public Material mat1;
	public Material mat2;
	public Material mat3;
	public Material mat4;
	private int currentWave;
	private int previousWave;
	private AssignGameController assignedGameController;
	// Use this for initialization
	void Start () {
		currentWave = 1;
		previousWave = 1;
		assignedGameController = GetComponent<AssignGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentWave=assignedGameController.gamecontroller.returnWave();
		Debug.Log ("currentwave:" + currentWave.ToString ());
		if (currentWave ==3) {
			gameObject.renderer.material=mat1;
			previousWave=currentWave;
		}
		else if (currentWave ==4)
		{
			gameObject.renderer.material=mat2;
		previousWave=currentWave;
		}
		else if (currentWave ==5)
		{
			gameObject.renderer.material=mat3;
			previousWave=currentWave;
		}
		else if (currentWave ==6)
		{
			gameObject.renderer.material=mat4;
			previousWave=currentWave;
		}
	}
}
