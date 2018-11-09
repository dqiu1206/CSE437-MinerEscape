using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player") {
			//Debug.Log("Spotted Player");
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.tag == "Player") {
			//Debug.Log("Player left vision");
		}
	}
}
