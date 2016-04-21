using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ProjectileComposite : MonoBehaviour {

	//RequireComponent Rigidbody;

	private List<Ability> abilities;
	private Entity sender;
	private float range = 1000.0f;
	private Vector3 startPosition;
//	private Rigidbody rb;

	public delegate void Effect(Entity sender, Entity receiver);
	private Effect effect;

	public void setEffect(Effect e){
		effect = e;
	}

	public void setSender(Entity s){
		sender = s;
	}

	public void setRange(float r){

		range = r;
	}

	void Start(){
		startPosition = transform.position;
//		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
//		movementPattern.step(rb);
//
//		foreach(iAbility a in abilities){
//			if(a.canExecute())
//				a.execute();
//		}
//
//		if(movementPattern.movementComplete())
//			Destroy(gameObject);
		range -= (transform.position - startPosition).magnitude;
		if(range <= 0)
			Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other){

		//Need checks to confirm collision was with valid target
		if(other.CompareTag(sender.tag)){
			return;
		}else if(!other.CompareTag("Wall")){
			Entity otherEntity = other.GetComponent<Entity>();
			effect(sender, otherEntity);
		}

//		if(otherEntity){
//			foreach(iEffect e in selfEffects){
//				e.execute(sender, otherEntity);
//			}
//
//			foreach(iEffect e in targetEffects){
//				e.execute(sender, otherEntity);
//			}
//		}

		Destroy(gameObject);
	}
}


