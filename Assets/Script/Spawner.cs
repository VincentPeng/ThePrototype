using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private const int max_level = 20;
	public Transform floor;
	private float curY = -70f;
	private const float distance = 20f;
	private long level = 0;


	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		SpawnFloorToFull();
	}

	private void SpawnFloorToFull() {
		while (level < max_level) {
			curY += distance;
			Instantiate(floor, new Vector3(-40f, curY, 0), Quaternion.identity);
			Instantiate(floor, new Vector3(0f, curY, 0), Quaternion.identity);
			Instantiate(floor, new Vector3(40f, curY, 0), Quaternion.identity);
			curY += distance;
			Instantiate(floor, new Vector3(0, curY, 0), Quaternion.identity);
			level += 2;
		}
	}
}
