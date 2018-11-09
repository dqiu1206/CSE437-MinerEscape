using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpScript : PickableItemScript {

	// Update is called once per frame
	public override void Update () {
		if (player != null) {//Powerup has been activated
			Destroy(gameObject);
		}
	}
	
	public override void Activate (GameObject p) {
		player = p;
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		player.GetComponent<PlayerMoveScript>().hasKey = true;
	}
}