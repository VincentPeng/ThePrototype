using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Hero hero;
	//private float Observe_length = 70;
	private float maxHealth = 100.0f;
	private float curHealth;
	private Animator anim;
	public AnimationClip dieClip;


	// Use this for initialization
	void Start() {
		curHealth = maxHealth;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
		//Attack();
	}

	public void Attack() {
		print("Enemy attacking");
		float distance = Mathf.Abs(hero.transform.position.x - transform.position.x);
		print(distance);
	}

	public void Damage() {
		print("Enemy taking damage");
		curHealth -= 50;
		if (curHealth <= 0) {
			Die();
		}
	}

	private void Die() {
		anim.Play(dieClip.name);
		Destroy(this.gameObject, dieClip.length);
	}
}
