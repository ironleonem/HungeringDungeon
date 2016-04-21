using UnityEngine;
using System.Collections;
using System;

public class ShootAtMouse : AttackPattern {

	float shotSpeed;

	public ShootAtMouse(float shotSpeed){
		this.shotSpeed = shotSpeed;
	}

	public void fire(ProjectileComposite p, Transform t, Action<ProjectileComposite> configure){

		//calculate angle to mouse
		float dist;

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane floor = new Plane(Vector3.up, 0.0f);
		floor.Raycast(mouseRay, out dist);
		Vector3 point = mouseRay.GetPoint(dist);
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
