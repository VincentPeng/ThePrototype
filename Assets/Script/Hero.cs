using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public float jumpPower = 300.0f;
	public bool grounded = true;
	public bool canDoubleJump = true;
	private Rigidbody2D rb2d;
	private Animator anim;
	private bool canTouch = false;


	// Use this for initialization
	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update() {
		anim.SetBool("Started", true);
		anim.SetBool("Grounded", grounded);
	}


	void FixedUpdate() {
		if (Input.touchCount > 0) { 
			Touch touch = Input.touches[0];

			if (touch.phase == TouchPhase.Began && canTouch) {
				// Make sure this will only be called once in one click.
				canTouch = false;
				if (grounded) {
					canDoubleJump = true;
					rb2d.AddForce(Vector2.up * jumpPower);
				} else if (canDoubleJump) {
					canDoubleJump = false;
					rb2d.velocity = new Vector2(0, 0);
					rb2d.AddForce(Vector2.up * jumpPower * 1.5f);
				}				
			} else if (touch.phase == TouchPhase.Ended) {
				// Once finger leaves, user can click again
				canTouch = true;
			}
		}
	}
}
