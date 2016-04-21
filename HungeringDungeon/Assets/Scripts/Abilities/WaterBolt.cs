using UnityEngine;
using System.Collections;

public class WaterBolt: Ability {

	public WaterBolt():base(2.0f, Resources.Load<ProjectileComposite>("shot_blue"), new ShootAtMouse(2.0f), 2.5f){

		//Debug.Log (Resources.Load<ProjectileComposite>("shot_blue"));
	}
	
	override public bool canFire(){
		return true;
	}
	
	override public void affectSelf(){}
	
	override public void effect(Entity sender, Entity receiver){
		//Debug.Log ("Hit with water bolt.");
		receiver.marks[MARKS.water].add(1);
		receiver.dealDamage(10);
		receiver.GetComponent<Rigidbody>().AddForce((receiver.transform.position - sender.transform.position).normalized * 2.0f);
	}
}
