using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public float baseSpeed = 5f;
    public float addSpeed = 0f;
	private float currentSpeed;
	private float teleportDistance = 20f;
	
	public bool hasKey = false;
	
	public int maxAmmo = 5;
	public int ammo;
	
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
    public float springSpeed = 100f;

    bool facingRight = true;

	bool wantsToShoot = false;
	bool wantsToTeleport = false;
	float teleportCooldown = 3f;
	float teleportCounter = 0;

	public Vector2 knockbackVector;
	public float knockbackLength = 1.0f;
	public float knockbackCount = 0.0f;
    private float lastSpike;
    private bool takeSpikeDamage = false;

    Rigidbody2D rb;

    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody2D>();
		currentSpeed = baseSpeed;
		ammo = maxAmmo;
    }
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			wantsToShoot = true;
		}
		
		if (Input.GetButtonDown("Fire2") && teleportCounter < 0) {
			wantsToTeleport = true;
			teleportCounter = teleportCooldown;
		} else {
			teleportCounter -= Time.deltaTime;
		}
	}
	
    //Fixed Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        
		if (move == 0) {
			GetComponent<Animator>().SetBool("isWalking", false);
		} else {
			GetComponent<Animator>().SetBool("isWalking", true);
		}
		

		if (knockbackCount <= 0) {
			rb.velocity = new Vector2((move * currentSpeed), rb.velocity.y);
		} else {
			rb.velocity = knockbackVector;
			knockbackCount -= Time.deltaTime;
		}

        if (move > 0 && !facingRight) {
            Flip();
        }
        else if (move < 0 && facingRight) {
            Flip();
        }
		
		if (wantsToShoot) {
			wantsToShoot = false;
			if (ammo > 0) {
				spawnBullet();
				ammo--;
			}
		}
		
		if (wantsToTeleport) {
			RaycastHit2D teleport;
			if (facingRight) {
				
				teleport = Physics2D.Raycast(transform.position, Vector2.right, teleportDistance, LayerMask.GetMask("Ground"));
			} else {
				teleport = Physics2D.Raycast(transform.position, Vector2.left, teleportDistance, LayerMask.GetMask("Ground"));
			}
			
			if (teleport.collider == true) {
				if (facingRight) {
					transform.position = new Vector3(transform.position.x + teleport.distance, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3(transform.position.x - teleport.distance, transform.position.y, transform.position.z);
				}
			} else {
				if (facingRight) {
					transform.position = new Vector3(transform.position.x + teleportDistance, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3(transform.position.x - teleportDistance, transform.position.y, transform.position.z);
				}
			}
			wantsToTeleport = false;
		}
		
        if (takeSpikeDamage)
        {
            if (Time.time - lastSpike > 1.0f)
            {
                this.GetComponent<Health>().TakeDamage(10);
                lastSpike = Time.time;
            }
        }
    }

    void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
	void spawnBullet() {
		GameObject bullet;

		if (facingRight) {
			bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			bullet.GetComponent<BulletScript>().Flip();
		} else {
			bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		}
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Destroy(bullet, 5f);
	}
	
	public void changeSpeedMultiplier(float multiplier) {
		currentSpeed = baseSpeed*multiplier;
	}
	
	public void ChangeScore(int x) {
		GameObject.Find("LevelManager").GetComponent<LevelManager>().IncreaseScore(x);
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Spikes")
        {
            takeSpikeDamage = true;
            
        }
        if(collision.gameObject.tag == "Spring")
        {
            rb.velocity = new Vector2(rb.velocity.x, springSpeed);
        }
    }
	
	public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spikes")
        {
            takeSpikeDamage = true;
            
        }
        if(collision.gameObject.tag == "Spring")
        {
            rb.velocity = new Vector2(rb.velocity.x, springSpeed);
        }
    }
	
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            takeSpikeDamage = false;
            lastSpike = 0f;

        }
    }
	
	public void giveMaxAmmo() {
		ammo = maxAmmo;
	}
}
