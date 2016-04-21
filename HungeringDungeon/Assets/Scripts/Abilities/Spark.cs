using UnityEngine;
using System.Collections;

public class Spark: Ability {
	
	public Spark():base(5.0f, Resources.Load<ProjectileComposite>("shot_red"), new ShootAtPlayer(4.5f), 3.5f){
		
		Debug.Log (base.cooldown+", "+base.pattern+", "+base.projectile+", "+base.range);
	}
	
	override public bool canFire(){
		return true;
	}
	
	override public void affectSelf(){}
	
	override public void effect(Entity sender, Entity receiver){

		//Debug.Log ("Hit with spark.");
		receiver.marks[MARKS.fire].add(1);
		receiver.dealDamage(20);

	}
}