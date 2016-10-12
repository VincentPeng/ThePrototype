using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour {

	public float jumpPower = 4000.0f;
	public float moveSpeed = 50.0f;

	private bool isMoving = false;
	public bool grounded = true;
	public bool canDoubleJump = true;

	private int curHealth = 5;
	private int maxHealth = 5;

	private Rigidbody2D rb2d;
	private Animator anim;

	private bool facingRight = true;

	private bool isLeftButtonDown = false;
	private bool isRightButtonDown = false;
	private bool isJumpButtonClick = false;
	//private bool isAttackButtonClick = false;
	private bool isAttacking = false;

	private float attackCd = 1;
	private float attackTimer = 0;

	public Collider2D attackTrigger;

	// Use this for initialization
	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		attackTrigger.enabled = false;
		curHealth = maxHealth;
	}

	void Update() {
		anim.SetBool("Move", isMoving);
		anim.SetBool("Grounded", grounded);
	}


	void FixedUpdate() {
//		if (Input.touchCount > 0) { 
//			Touch touch = Input.touches[0];
//
//			if (touch.phase == TouchPhase.Began && canTouch) {
//				// Make sure this will only be called once in one click.
//				canTouch = false;
//				if (grounded) {
//					canDoubleJump = true;
//					rb2d.AddForce(Vector2.up * jumpPower * rb2d.gravityScale);
//					grounded = false;
//				} else if (canDoubleJump) {
//					canDoubleJump = false;
//					rb2d.velocity = new Vector2(0, 0);
//					rb2d.AddForce(Vector2.up * jumpPower * 1.5f * rb2d.gravityScale);
//					rb2d.gravityScale *= -1;
//				}				
//			} else if (touch.phase == TouchPhase.Ended) {
//				// Once finger leaves, user can click again
//				canTouch = true;
//			}
//		}

		if (isJumpButtonClick) {
			isJumpButtonClick = false;
			if (grounded) {
				canDoubleJump = true;
				rb2d.AddForce(Vector2.up * jumpPower);
				grounded = false;
			} else if (canDoubleJump) {
				canDoubleJump = false;
				rb2d.velocity = new Vector2(0, 0);
				rb2d.AddForce(Vector2.up * jumpPower * 1.5f);
			}
		}


		if (isLeftButtonDown) {
			rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
		} else if (isRightButtonDown) {
			rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
		} else {
			rb2d.velocity = new Vector2(0, rb2d.velocity.y);
		}

		if (isAttacking) {
			attackTimer -= Time.deltaTime;
			if (attackTimer < 0) {
				isAttacking = false;
				attackTimer = 0;
				attackTrigger.enabled = false;
			}
		}
	}

	void Die() {
		print("Die");
		SceneManager.LoadScene("Main");
	}

	public void Attack() {
		//if (isAttackButtonClick) {
		if (isAttacking) {
			// Ignore
		} else {
			isAttacking = true;
			attackTrigger.enabled = true;
			attackTimer = attackCd;
			anim.SetTrigger("Attack");
		}

		//}
	}

	public void GetDamage(int damage) {
		curHealth -= damage;
		if (curHealth <= 0) {
			Die();
		}
	}

	public void OnMoveLeftButtonDown() {
		print("l t");
		isLeftButtonDown = true;
		isMoving = true;
		if (facingRight) {
			Flip();
		}
	}

	public void OnMoveLeftButtonUp() {
		isLeftButtonDown = false;
		isMoving = false;
	}

	public void OnMoveRightButtonDown() {
		print("r t");
		isRightButtonDown = true;
		isMoving = true;
		if (!facingRight) {
			Flip();
		}
	}

	public void OnMoveRightButtonUp() {
		isRightButtonDown = false;
		isMoving = false;
	}

	public void OnJumpButtonClick() {
		isJumpButtonClick = true;
	}


	private void Flip() {
		facingRight = !facingRight;
		Vector3 curScale = transform.localScale;
		curScale.x *= -1;
		transform.localScale = curScale;
	}


}
