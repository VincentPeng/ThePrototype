using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

	public float moveSpeed = 3.0f;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		transform.position += Vector3.left * moveSpeed;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			print("hit");
			Hero hero = col.gameObject.GetComponent<Hero>();
			hero.GetDamage(1);
		}
	}
}
