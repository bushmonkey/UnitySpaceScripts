using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyShotDetails
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
}

public class EnemyFire : MonoBehaviour {
	public EnemyShotDetails shotDetails;
	private float nextFire = 0.5f;
	
	void Update () 
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + shotDetails.fireRate;
			Instantiate (shotDetails.shot, shotDetails.shotSpawn.position, shotDetails.shotSpawn.rotation);
		}
	}
}
