using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float velX;
	public int enemyLayer = 11;
	public float bulletDamage;
	private bool facingRight = false;
		
	Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(-velX, 0f);
	}
	
	public void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		velX = -velX;		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer != 0)
        {
            Debug.Log("Layer != 0");
            if(coll.gameObject.layer == enemyLayer)
            {
                coll.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
                Destroy(this.gameObject);
            }
            if(coll.gameObject.layer == 8 || coll.gameObject.layer == 15)
            {
                Destroy(this.gameObject);
            }
        }


		/*if (coll.gameObject.layer == collisionLayer) {
			
		} else if (coll.gameObject.layer != 0){
            Destroy(gameObject);
        } else if (coll.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
			Destroy(gameObject);
			Destroy(coll.gameObject);
		}*/
    }
}
