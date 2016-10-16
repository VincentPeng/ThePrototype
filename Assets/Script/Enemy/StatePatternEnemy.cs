using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour {
	public float idleDuration = 2f;
	public float moveSpeed = 2.0f;
	private bool facingRight = false;
	private Rigidbody2D rb2d;
	private float maxHealth = 100.0f;
	private float curHealth;
	public AnimationClip dieClip;

	private Canvas HealthCanvas;

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public WalkState walkState;
	[HideInInspector] public Animator anim;

	private void Awake() {
		idleState = new IdleState(this);
		attackState = new AttackState(this);
		walkState = new WalkState(this);
	}

	// Use this for initialization
	void Start() {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		currentState = walkState;
		curHealth = maxHealth;
		HealthCanvas = GetComponentInChildren<Canvas>();
	}
	
	// Update is called once per frame
	void Update() {
		currentState.UpdateState();
	}

	private void OnTriggerEnter2D(Collider2D col) {
		currentState.OnTriggerEnter2D(col);
	}

	private void OnTriggerExit2D(Collider2D col) {
		currentState.OnTriggerExit2D(col);
	}

	public void Walk() {
		if (facingRight) {
			rb2d.velocity = new Vector2(moveSpeed, 0);
		} else {
			rb2d.velocity = new Vector2(-moveSpeed, 0);
		}
	}

	public void Stop() {
		rb2d.velocity = Vector2.zero;
	}

	public void Flip() {

		// In case of Health bar flip as well, get it out of hierarchy first
		HealthCanvas.transform.SetParent(null);

		facingRight = !facingRight;
		Vector3 curScale = transform.localScale;
		curScale.x *= -1;
		transform.localScale = curScale;

		// Put the Canvas back to the hierarchy
		HealthCanvas.transform.SetParent(this.transform);
	}

	public void Damage() {
		print("Enemy taking damage");
		curHealth -= 50;
		if (curHealth <= 0) {
			Die();
		}
	}

	public void Die() {
		anim.Play(dieClip.name);
		Destroy(this.gameObject, dieClip.length);
	}
}
