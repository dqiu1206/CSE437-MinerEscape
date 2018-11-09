using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnEnemyContact : MonoBehaviour {

	Rigidbody2D rb;
	public float knockback = 1f;
	public float knockbackLength = 0.5f;
	
	public float damage = 20f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		//If Player runs into an enemy
		if (coll.gameObject.layer == 10) {
			var playerScript = coll.gameObject.GetComponent<PlayerMoveScript>();
			var playerHealth = coll.gameObject.GetComponent<Health>();
			if (coll.gameObject.transform.position.x < transform.position.x) {
				playerScript.knockbackVector = knockback*(new Vector2(-1f,0.5f));
			} else {
				playerScript.knockbackVector = knockback*(new Vector2(1f,0.5f));
			}
			playerScript.knockbackLength = knockbackLength;
			playerScript.knockbackCount = knockbackLength;
			
			playerHealth.TakeDamage(damage);
		}
    }	
}
