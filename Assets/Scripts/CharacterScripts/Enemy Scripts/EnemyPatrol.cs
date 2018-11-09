using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
    
	public float speed = 10f;
	public float attackSpeed = 2f;
	public int pointValue = 50;
	
	private float attackCounter = 0;
	private GameObject player;
	
	
    bool isRight = true;
    public Transform groundDetection;
	public Transform wallDetection;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	
	private float lastHealth;
	
    Rigidbody2D rigid2D;	
	Health enemyHealth;
	
    // Use this for initialization
    void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
		enemyHealth = GetComponent<Health>();
		player = GameObject.Find("RobotPlayer");
		lastHealth = enemyHealth.currentHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
		attackCounter -= Time.deltaTime;
		
		healthCheck();
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
		RaycastHit2D wall;
		if (isRight) {
			wall = Physics2D.Raycast(wallDetection.position, Vector2.right, 2f, LayerMask.GetMask("Walls"));
		} else {
			wall = Physics2D.Raycast(wallDetection.position, Vector2.left, 2f, LayerMask.GetMask("Walls"));
		}
		
		Debug.Log(LayerMask.GetMask("Ground"));
		
        if(ground.collider == false || wall.collider == true)
        {
            Flip();
        }
	}
	
	void healthCheck() {
		
		//Has been damaged
		if (lastHealth > enemyHealth.currentHealth) {
			lastHealth = enemyHealth.currentHealth;
			GetComponent<Animation>().Play("robotFlashRed");
		}
		
		if (lastHealth <= 0) {
			player.GetComponent<PlayerMoveScript>().ChangeScore(pointValue);
			Destroy(gameObject);
		}
	}
	
    void Flip()
    {
        if (isRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
    }
	
	void spawnBullet() {
		GameObject bullet;

		if (isRight) {
			bullet = (GameObject)Instantiate (bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
			bullet.GetComponent<BulletScript>().Flip();
		} else {
			bullet = (GameObject)Instantiate (bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
		}
        Destroy(bullet, 30f);
	}
	
	public void Attack() {
		if (attackCounter <= 0) {
			attackCounter = attackSpeed;
			spawnBullet();
		}
	}
	
	public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spikes")
        {
            Flip();
            
        }
    }
}
