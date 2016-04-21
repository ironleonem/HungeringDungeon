using System.Collections;
using System;
using UnityEngine;

public class ShootAtPlayer : AttackPattern {
	
	float shotSpeed;
	
	public ShootAtPlayer(float shotSpeed){
		this.shotSpeed = shotSpeed;
	}
	
	public void fire(ProjectileComposite p, Transform t, Action<ProjectileComposite> configure){

		GameObject player = GameObject.FindWithTag("Player");

		if(player!=null){ 
			Vector3 point = player.transform.position;

			Vector3 shotDirection = (point-t.position).normalized;
			
			//place projectile
			Vector3 projectilePosition = t.position + shotDirection;
			ProjectileComposite clone = ProjectileComposite.Instantiate(p, projectilePosition, Quaternion.identity) as ProjectileComposite;
			
			//set projectile
			configure(clone);
			
			//launch
			clone.GetComponent<Rigidbody>().velocity = shotDirection * shotSpeed;
		}
	}
}