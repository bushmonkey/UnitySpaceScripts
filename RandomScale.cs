using UnityEngine;
using System.Collections;

public class RandomScale : MonoBehaviour {
	//public float tumble;
	// Use this for initialization
	void Start () {
		transform.localScale = Random.insideUnitSphere;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
