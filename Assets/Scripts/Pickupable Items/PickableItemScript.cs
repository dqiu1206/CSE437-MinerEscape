using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemScript : MonoBehaviour {

	public float duration = 5f;
	public float counter;
	public GameObject player = null;
	
	private int playerLayer = 10;

	// Use this for initialization
	void Start () {
		counter = duration;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		//If Player runs into an enemy
		if (coll.gameObject.layer == playerLayer) {
			Activate(coll.gameObject);
			GetComponent<Renderer>().enabled = false;
		}
    }
	
	public virtual void Activate(GameObject p) {}
}
