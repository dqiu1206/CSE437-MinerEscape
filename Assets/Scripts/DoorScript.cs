using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {

	private int playerLayer = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		//If Player runs into an enemy
		if (coll.gameObject.layer == playerLayer) {
			GameObject player = coll.gameObject;
			
			if (player.GetComponent<PlayerMoveScript>().hasKey == true) {
				Debug.Log("Player Has Exited Level!!");
                SceneManager.LoadScene("Main_Menu");
				Destroy(gameObject);
			}
		}
    }
}
