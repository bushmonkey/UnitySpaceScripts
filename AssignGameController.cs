using UnityEngine;
using System.Collections;

public class AssignGameController : MonoBehaviour {
	public GameController gamecontroller;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gamecontroller = gameControllerObject.GetComponent <GameController>();
		}
	}
}
