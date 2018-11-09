using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			if (Input.GetKey(KeyCode.UpArrow)) {
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
				Debug.Log("Going up");
			} else if (Input.GetKey(KeyCode.DownArrow)) {
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
			} else {
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1.2f);
			}
		}
	}
}
