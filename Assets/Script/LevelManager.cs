using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float splashTime = 8.0f;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start() {
		Invoke("LoadNextLevel", splashTime);
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
