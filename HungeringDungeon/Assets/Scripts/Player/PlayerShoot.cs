using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	RequireComponent Entity;

	private Ability qAbility;
	private Entity entity;

	// Use this for initialization
	void Start () {
		qAbility = new WaterBolt();
		entity = GetComponent<Entity>();
		//Debug.Log ("Entity from player = "+entity);
	}
	
	// Update is called once per frame
	void Update () {

		qAbility.update();

		if(Input.GetKeyDown(KeyCode.Q) && qAbility.canExecute()){
			qAbility.execute(entity);
		}
	}
}
