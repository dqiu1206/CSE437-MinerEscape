using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {

	public float jumpForce;
	
	public Transform groundDetection;
	public LayerMask groundLayer;

	public float fallMultiplier = 2.5f;
	public float riseMultiplier = 1f;
	
	public int extraJumps = 1;
	public int jumpCounter;
	
	
	bool wantsToJump = false;
	public bool isJumping = false;
	public bool didExtraJump = false;
	public bool onGround;
	
	Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
	}
	
	bool isGrounded() {
		return Physics2D.OverlapCircle(groundDetection.position, 0.1f, groundLayer);
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			wantsToJump = true;
		}
	}
	
	void FixedUpdate () {
		
		onGround = isGrounded();
		
		if (isGrounded()) {
			isJumping = false;
			jumpCounter = 0;
			didExtraJump = false;
		}
		
		if (wantsToJump && isGrounded() && !isJumping)
        {
			isJumping = true;
            Jump();
			wantsToJump = false;
        } else if (wantsToJump && !isGrounded() && jumpCounter < extraJumps) {
			isJumping = true;
			jumpCounter++;
			rb.velocity = new Vector2(rb.velocity.x, 0f);
			Jump();
			didExtraJump = true;
			wantsToJump = false;
		}
		
		velocityCheck();
	}
	
	void velocityCheck () {
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.UpArrow)) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (riseMultiplier) * Time.deltaTime;
		}
	}
	
	 void Jump() {
		rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
