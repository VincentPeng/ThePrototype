using UnityEngine;
using System.Collections;

public class WalkState : IEnemyState {

	private readonly StatePatternEnemy enemy;

	public WalkState(StatePatternEnemy enemy)
	{
		this.enemy = enemy;
	}

	public void UpdateState() {
		Walk();
	}

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			Debug.Log("See Player");
			enemy.Stop();
			ToAttackState();
		} else if (col.CompareTag("Edge")) {
			Debug.Log("meet edge");
			ToIdleState();
		}
	}

	public void OnTriggerExit2D(Collider2D col) {

	}

	public void ToIdleState() {
		enemy.Stop();
		enemy.anim.SetTrigger("Edge");
		enemy.currentState = enemy.idleState;
	}

	public 	void ToWalkState() {
		Debug.Log("Should not see this transition!!");
	}

	public 	void ToAttackState() {
		enemy.anim.SetBool("Attack", true);
		enemy.currentState = enemy.attackState;
	}

	void Walk() {
		// velocity stuff
		enemy.Walk();
	}


}
