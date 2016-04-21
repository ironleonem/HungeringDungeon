using UnityEngine;
using System.Collections;

public class enemyNavMove : MonoBehaviour {

	public float playerRadius = 2.0f;
	private NavMeshAgent agent;
	private Rigidbody rb; 
	private Transform player;
	
	void Start(){
		rb = this.GetComponent<Rigidbody>();
		agent = this.GetComponent<NavMeshAgent>();

		player = GameObject.FindWithTag("Player").transform;
		Debug.Log ("player = "+player);

		chooseRandomDest();
	}
	
	// Update is called once per frame
	void Update () {
		//avoidDanger();
		if (agent.remainingDistance < 0.5f)
			chooseRandomDest();
	}

	void chooseRandomDest(){

		Vector3 dest = new Vector3(Random.Range (-6.25f, 6.25f), 0.0f, Random.Range(-15.25f, 15.25f));
		if(player==null || (dest-player.position).magnitude > playerRadius )
			agent.SetDestination(dest);
		//if (agent.remainingDistance < 0.5f)
		//	chooseRandomDest();
	}

//	void chooseDestInDirection(Vector3 v){
//
//		float dist = Random.Range(0.5f, 4.0f);
//		Vector3 dest = dist * v;//new Vector3(Random.Range (-4.75f, 4.75f), Random.Range(-10.75f, 10.75f), 0.0f);
//		if((dest-transform.position).magnitude > 0.5 && (dest-transform.position).magnitude < 4.0 && (dest-player.position).magnitude > playerRadius)
//			agent.SetDestination(dest);
//		//if (agent.remainingDistance < 0.5f)
//		//	chooseRandomDest();
//	}

//	void OnCollisionEnter(Collision col){
//
//		chooseDestInDirection((col.transform.position - transform.position));
//
//	}

//	void avoidDanger(){
//		Collider[] threats = Physics.OverlapSphere(transform.position, rb.velocity.magnitude * reactionRadius);
//		if(threats.Length > 0){
//			Vector3 safeDirection = new Vector3(0.0f, 0.0f, 0.0f);
//			foreach(Collider c in threats){
//				safeDirection = (safeDirection - (c.transform.position - transform.position).normalized).normalized;
//			}
//			Debug.Log ("Avoided");
//			agent.SetDestination(safeDirection * rb.velocity.magnitude);
//		}
//	}
}
