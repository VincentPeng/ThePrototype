using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform hero;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		if (hero.position.y > transform.position.y) {
			FollowHero();
		}
	}

	private void FollowHero() {
		Debug.Log("follow");
		Vector3 curPos = transform.position;
		curPos.y = hero.position.y;
		transform.position = curPos;
	}
}
