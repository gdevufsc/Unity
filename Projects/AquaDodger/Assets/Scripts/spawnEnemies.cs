using UnityEngine;
using System.Collections;

public class spawnEnemies : MonoBehaviour {

	Vector3 spawnPoint;

	public GameObject evilPrefab, evilPrefab2, gunPrefab, timePrefab;
	float timer = 0;
	public float respawnTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= respawnTime) {
			spawnPoint = new Vector3 ( 10f, ((float)Random.Range (-400,400))/100f, 0f );
			if( Random.Range(0,10) == 1 ){ //spawn power-up
				if( Random.Range(0,3) == 1 ){// power: time
					GameObject clone = (GameObject)Instantiate (timePrefab, spawnPoint, Quaternion.identity);
					clone.AddComponent(typeof(powerBehaviour));
					clone.name = "timePower";
				}
				else{// power: gun
					GameObject clone = (GameObject)Instantiate (gunPrefab, spawnPoint, Quaternion.identity);
					clone.AddComponent(typeof(powerBehaviour));
					clone.name = "gunPower";
				}
			}
			else{ //spawn monster
				if( Random.Range(0,2) == 1 ){
					GameObject clone = (GameObject)Instantiate (evilPrefab2, spawnPoint, Quaternion.identity);
					clone.AddComponent(typeof(enemyBehaviour));
					clone.name = "enemy";
				}
				else{
					GameObject clone = (GameObject)Instantiate (evilPrefab, spawnPoint, Quaternion.identity);
					clone.AddComponent(typeof(enemyBehaviour));
					clone.name = "enemy";
				}
			}
			timer = 0;
		} else {
			timer+= Time.deltaTime;
		}
	}
}
