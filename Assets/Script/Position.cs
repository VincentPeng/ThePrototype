using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	public Bat bat;
	public float spawnTime = 3.0f;

	void Start() {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Update() {
		
	}

	void Spawn() {
		Instantiate(bat, transform.position, Quaternion.identity);
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
