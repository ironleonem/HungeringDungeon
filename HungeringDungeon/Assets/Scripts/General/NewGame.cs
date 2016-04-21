using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
			Application.LoadLevel("OneRoom");
	}
}
