using UnityEngine;
using System.Collections;

public class AttackState : IEnemyState {

	private readonly StatePatternEnemy enemy;

	public AttackState(StatePatternEnemy enemy)
	{
		this.enemy = enemy;
	}

	public void UpdateState() {
		Attack();
	}

	public void OnTriggerEnter2D(Collider2D col) {
		
	}

	public void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			Debug.Log("Player leaves");
			ToWalkState();
		}
	}

	public void ToIdleState() {
		
	}

	public void ToWalkState() {
		enemy.anim.SetBool("Attack", false);
		enemy.currentState = enemy.walkState;
	}

	public void ToAttackState() {
		Debug.Log("Should not see this transition!!");
	}

	private void Attack() {
		Debug.Log("Attacking");
	}
}
