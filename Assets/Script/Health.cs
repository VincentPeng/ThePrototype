using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Sprite[] healthSprites;
	private Image healthUI;
	public Hero hero;


	// Use this for initialization
	void Start() {
		healthUI = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update() {
		healthUI.sprite = healthSprites[hero.curHealth];
	}
}
