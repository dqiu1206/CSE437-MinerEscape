using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : PickableItemScript {
	
	public float respawnTimer = 15f;
	
	// Update is called once per frame
	public override void Update () {
		if (player != null) {//Powerup has been activated
			if (counter > 0) {
				//player.GetComponent<Health>().TurnOnInvincibility();
			} else if (counter > -respawnTimer + duration){
				player.GetComponent<Health>().TurnOffInvincibility();
				//Destroy(gameObject);
			} else {
				GetComponent<Renderer>().enabled = true;
				player = null;
			}
			counter -= Time.deltaTime;
		}
	}
	
	public override void Activate (GameObject p) {
		player = p;
		counter = duration;
		player.GetComponent<Health>().TurnOnInvincibility();
	}
}
