using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	public int chosenPath;
	public int tweenSpeed;
	// Use this for initialization
	private int randomPath;

	void Start () {
		if (chosenPath == 1) {
			randomPath = Random.Range(0,10);
			if (randomPath>5)
			{
				tweenSpeed = 20;
				iTween.MoveTo(gameObject,iTween.Hash("path",iTweenPath.GetPath("BadGuy"),"time",tweenSpeed));
			}
			else
			{
				tweenSpeed = 20;
				iTween.MoveTo(gameObject,iTween.Hash("path",iTweenPath.GetPath("BadGuyCircle"),"time",tweenSpeed));
			}
		} else {
			rigidbody.velocity = transform.forward * speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
