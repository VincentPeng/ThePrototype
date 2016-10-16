using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col) {
		print("attack trigger enter");
		if (col.CompareTag("Enemy")) {
			print("Enemy enter trigger");
			col.SendMessageUpwards("Damage");
		}
	}
}
