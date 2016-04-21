using UnityEngine;
using System.Collections;

public class EnemyShootAtPlayer : MonoBehaviour {

	RequireComponent Entity;
	
	private Ability qAbility;
	private Entity entity;

//	public float speed;
//	public float firingInterval;
//	float intervalRemaining;
//	public Transform projectile;
//	Ability attack;
	// Use this for initialization

	void Start () {
		qAbility = new Spark();
		entity = GetComponent<Entity>();

	}
	
	// Update is called once per frame
	void Update () {

		qAbility.update();

		if(qAbility.canExecute()){
			qAbility.execute(entity);
		}
	}

//	void shoot(){
//		if(player!=null){
//
//			Vector3 shotDirection = (player.position-transform.position).normalized;
//			
//			//place projectile
//			Vector3 projectilePosition = transform.position + shotDirection * 1.5f;
//			Transform clone = Instantiate(projectile, projectilePosition, Quaternion.identity) as Transform;
//			attack.setShot(clone.GetComponent<Projectile>());
//			clone.GetComponent<Rigidbody>().velocity = speed * shotDirection; 
//		}
//	}

//	bool hasClearShot(){
////		Ray shotRay = new Ray(transform.position, player.position);
////		RaycastHit shotInfo;
////		Physics.Raycast(shotRay, out shotInfo);
////		bool res = true;
////
////		if(shotInfo.transform)
////		 	res = !shotInfo.transform.CompareTag("Enemy");
//
//		//if(player)
//
//		if(res)
//			Debug.DrawLine(transform.position, player.position, new Color(0.0f,255.0f,0.0f), 0.1f);
//		else
//			Debug.DrawLine(transform.position, player.position, new Color(255.0f,0.0f,0.0f), 0.1f);
//		return res;
//	}
}
