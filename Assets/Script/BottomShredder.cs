using UnityEngine;
using System.Collections;

public class BottomShredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		print("Shredder Entered");
		if (col.CompareTag("Player")) {
			print("Player entered");
			col.SendMessage("Die");
		}
	}
}
