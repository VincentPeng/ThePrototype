using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	
	// Update is called once per frame
	void Update() {
	
	}

	public void Pause() {
		Time.timeScale = 0.0f;
	}
}
