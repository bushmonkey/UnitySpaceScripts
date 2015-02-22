using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject hazard2;
	public GameObject enemyShip;
	public GameObject enemyShip2;
	public GameObject enemyShip3;
	public Vector3 spawnValues;
	public float spawnWait;
	public float waveWait;
	public int HazardCount;
	public Text scoreText;
	public Text GameoverText;
	public Text RestartText;
	public Text waveText;
	public Text multiplierText;
	public GameObject EnemyExplosion;

	private int score;
	private int randomTiming;
	private int multiplier;
	private float randomSpawn;
	private bool isGameOver;
	private bool isRestart;
	private int waveNumber;

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (waveWait);
		while (true) {
			waveText.text="";
			randomSpawn = Random.Range (1*waveNumber, HazardCount*waveNumber);
			for (int i=0; i<randomSpawn; i++) {
				randomTiming = Random.Range (0, 10);
				Vector3 SpawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion SpawnRotation = Quaternion.identity;
				if (waveNumber < 4)
				{
					if (randomTiming==1){
						Instantiate (enemyShip, SpawnPosition, enemyShip.transform.rotation);
					}
					else if (randomTiming < 6) {
						Instantiate (hazard, SpawnPosition, SpawnRotation);
					} else {
						Instantiate (hazard2, SpawnPosition, SpawnRotation);
					}
				}
				else if (waveNumber < 8)
				{
					if (randomTiming==1){
						Instantiate (enemyShip2, SpawnPosition, enemyShip2.transform.rotation);
					}
					else if (randomTiming==2){
						Instantiate (enemyShip3, SpawnPosition, enemyShip3.transform.rotation);
					}
					else if (randomTiming<4){
						Instantiate (enemyShip, SpawnPosition, enemyShip.transform.rotation);
					}
					else if (randomTiming < 7) {
						Instantiate (hazard, SpawnPosition, SpawnRotation);
					} else {
						Instantiate (hazard2, SpawnPosition, SpawnRotation);
					}
				}
				else
				{
					if (randomTiming == 1){
						Instantiate (enemyShip, SpawnPosition, enemyShip.transform.rotation);
					}
					else if (randomTiming < 4){
						Instantiate (enemyShip2, SpawnPosition, enemyShip2.transform.rotation);
					}
					else if (randomTiming < 6){
						Instantiate (enemyShip3, SpawnPosition, enemyShip3.transform.rotation);
					}
					else if (randomTiming < 7) {
						Instantiate (hazard, SpawnPosition, SpawnRotation);
					} else {
						Instantiate (hazard2, SpawnPosition, SpawnRotation);
					}
				}
				yield return new WaitForSeconds (spawnWait);
			}
			waveNumber+=1;
			waveText.text = "Wave " + waveNumber.ToString();
			yield return new WaitForSeconds (waveWait);
			if (isGameOver)
			{
				waveText.text="";
				RestartText.text="Press 'R' for restart";
				isRestart=true;
				break;
			}
		}
	}
	// Use this for initialization
	void Start () 
	{
		waveNumber = 1;
		multiplier = 1;
		score = 0;
		UpdateScore();
		StartCoroutine (SpawnWaves ());
		isGameOver = false;
		isRestart = false;
		GameoverText.text = "";
		RestartText.text = "";
		waveText.text = "Wave " + waveNumber.ToString();
	}

	void Update()
	{
		if (isRestart) 
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	void UpdateScore () {
		scoreText.text = "Score: " + score.ToString();
		multiplierText.text = "x" + multiplier.ToString ();
	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue*multiplier;
		UpdateScore ();
	}

	public void IncreaseMultiplier()
	{
		multiplier += 1;
	}

	public void GameOver()
	{
		GameoverText.text = "Game over";
		isGameOver = true;
		foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
			if (o.tag=="Enemy")
			{
				Instantiate(EnemyExplosion,o.transform.position,o.transform.rotation); 	
				Destroy(o);
			}
		}
	}

	public int returnWave()
	{
		return waveNumber;
	}
}
