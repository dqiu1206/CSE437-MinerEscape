using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRadiusScript : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		enemy = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player") {
			//enemy.GetComponent<EnemyPatrol>().Attack();
			//Debug.Log("Will attack Player");
		}
	}
	
	void OnTriggerStay2D(Collider2D coll) {
		if (coll.tag == "Player") {
			enemy.GetComponent<EnemyPatrol>().Attack();
			Debug.Log("Will attack Player");
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.tag == "Player") {
			//enemy.GetComponent<EnemyPatrol>().Attack();
		}
	}
}
