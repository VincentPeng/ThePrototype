using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private bool isAttacking = false;

	private float attackCd = 0.3f;
	private float attackTimer = 0f;

	public Collider2D attackTrigger;
	private Animator anim;


	void Awake() {
		attackTrigger.enabled = false;
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {

		if (isAttacking) {
			attackTimer -= Time.deltaTime;
			if (attackTimer < 0) {
				isAttacking = false;
				attackTimer = 0f;
				attackTrigger.enabled = false;
			}
		}

		anim.SetBool("Attack", isAttacking);
	}



	public void Attack() {
		if (isAttacking) {
			// Ignore
		} else {
			isAttacking = true;
			attackTrigger.enabled = true;
			attackTimer = attackCd;
		}

		//}
	}
}
