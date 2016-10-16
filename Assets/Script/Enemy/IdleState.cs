using UnityEngine;
using System.Collections;

public class IdleState : IEnemyState {

	private readonly StatePatternEnemy enemy;

	private float idleTimer;

	public IdleState(StatePatternEnemy enemy)
	{
		this.enemy = enemy;
	}

	public void UpdateState() {
		Idle();
	}

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			Debug.Log("See Player");
			ToAttackState();
		}
	}

	public void OnTriggerExit2D(Collider2D col) {

	}

	public void ToIdleState() {
		Debug.Log("Should not see this transition!!");
	}

	public void ToWalkState() {
		enemy.currentState = enemy.walkState;
		idleTimer = 0f;
	}

	public 	void ToAttackState() {
		enemy.anim.SetBool("Attack", true);
		enemy.currentState = enemy.attackState;
		idleTimer = 0f;
	}

	private void Idle() {
		idleTimer += Time.deltaTime;

		if (idleTimer > enemy.idleDuration) {
			enemy.Flip();
			ToWalkState();
		}
	}
}
