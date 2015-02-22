using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShotDetails
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
}

public class ShotControl : MonoBehaviour {
	public bool isTurnedOn;
	public ShotDetails shotDetails;
	private float nextFire = 0.0f;

	void Update () 
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire && isTurnedOn) 
		{
			nextFire = Time.time + shotDetails.fireRate;
			Instantiate (shotDetails.shot, shotDetails.shotSpawn.position, shotDetails.shotSpawn.rotation);
		}
	}
	public void SwitchSpawn(bool switchStatus)
	{
		isTurnedOn = switchStatus;
		Debug.Log ("turned off");
	}
}
