using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponScript : MonoBehaviour {
	
	Animator anim;
	
	public float weaponDamage = 5f;
	public int collisionLayer;
	public bool wantToAttack = false;
	
	public bool didAttack = false;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Fire1")) {
			wantToAttack = true;
		} else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.IsInTransition(0)) {
				//isAttacking = false;
		}
	}
	
	void FixedUpdate () {
		if (wantToAttack) {
			//anim.ResetTrigger("MakeIdle");
			anim.SetTrigger("Attack");
			wantToAttack = false;
			didAttack = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.layer == collisionLayer && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && didAttack == false) {			
			print("why is it not attacking");
			coll.gameObject.GetComponent<Health>().TakeDamage(weaponDamage);
			didAttack = true;
        } else if (coll.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
			//Destroy(coll.gameObject);
		}	
    }
	
		void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.layer == collisionLayer && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && didAttack == false) {			
			print("why is it not attacking");
			coll.gameObject.GetComponent<Health>().TakeDamage(weaponDamage);
			didAttack = true;
        } else if (coll.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
			//Destroy(coll.gameObject);
		}	
    }
}
