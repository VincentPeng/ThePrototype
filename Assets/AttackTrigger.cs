using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		print("attack trigger enter");
		if (col.CompareTag("Enemy")) {
			print("Enemy enter trigger");
			col.SendMessageUpwards("Damage");
		}
	}
}
