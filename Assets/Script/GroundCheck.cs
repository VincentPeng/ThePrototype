using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Hero hero;

	// Use this for initialization
	void Start() {
		hero = GetComponentInParent<Hero>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Floor")) {
			hero.grounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.CompareTag("Floor")) {
			hero.grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag("Floor")) {
			hero.grounded = false;
			hero.canDoubleJump = true;
		}
	}

}
