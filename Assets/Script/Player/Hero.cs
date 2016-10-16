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

	// Use this for initialization
	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		curHealth = maxHealth;
	}

	void Update() {
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
	}

	void FixedUpdate() {

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

	}

	public void Die() {
		print("Die");
		LevelManager.RestartGame();
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
