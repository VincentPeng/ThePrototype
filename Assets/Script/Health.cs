using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	private Image health;
	public Hero hero;


	void Start() {
		health = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.W)) {
			health.fillAmount -= 0.1f;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			health.fillAmount += 0.1f;
		}
	}
}
