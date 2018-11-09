using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickableItemScript {

	public int pointValue = 100;

	// Update is called once per frame
	public override void Update () {
		if (player != null) {//Powerup has been activated
			Destroy(gameObject);
		}
	}
	
	public override void Activate (GameObject p) {
		player = p;
		player.GetComponent<PlayerMoveScript>().ChangeScore(pointValue);
	}
}