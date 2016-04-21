using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float timeTillDeath;
	//float timeRemainingTillDeath;
	public float spawnInterval;

	

	// Use this for initialization
	void Start () {
		InvokeRepeating("spawn", spawnInterval, spawnInterval);
	}
	
	// Update is called once per frame
	void Update () {
		if(timeTillDeath<=0.0f){
			Destroy(this.gameObject);
		}else{
			timeTillDeath -= Time.deltaTime;
		}
	}

	void spawn(){
		Instantiate(enemy, this.transform.position, Quaternion.identity);
	}
}
