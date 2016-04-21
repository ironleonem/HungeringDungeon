using UnityEngine;
using System.Collections;
using System;

public abstract class Ability  {

	public float cooldown = 0.0f;
	public ProjectileComposite projectile;
	public AttackPattern pattern;
	public float range;

	private float timeRemaining;

	protected Ability(float c, ProjectileComposite p, AttackPattern ap, float r){
		cooldown = c;
		projectile = p;
		pattern = ap;
		range = r;
	}

	public void execute(Entity sender){
		projectile.setEffect(effect);
		//Debug.Log ("using sender: "+sender);
		projectile.setSender(sender);

		pattern.fire(projectile, sender.transform, createConfigFunction(sender));

		timeRemaining = cooldown;
	}
	
	public bool canExecute(){
		if(projectile==null || pattern == null){
			Debug.LogError("Null ability component prevented firing. Projectile: "+projectile+" Pattern: "+pattern);
			return false;
		}
		return timeRemaining<=0.0f && canFire();
	}

	public void update(){
		if(timeRemaining>0.0f){
			timeRemaining -= Time.deltaTime;
			timeRemaining = Mathf.Max(0.0f, timeRemaining);
		}
	}

	public Action<ProjectileComposite> createConfigFunction(Entity sender){

		return delegate(ProjectileComposite p) {
			p.setSender(sender);
			p.setEffect(effect);
			p.setRange(range);
		};
	}

	public abstract bool canFire();
	public abstract void affectSelf();
	public abstract void effect(Entity sender, Entity receiver);
}
