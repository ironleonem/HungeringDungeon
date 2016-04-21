﻿using UnityEngine;
using System.Collections;

public class playerNavMove : MonoBehaviour {

	NavMeshAgent agent;

	void Start(){
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hit;
			
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				agent.destination = hit.point;
			}
		}
	}
}
