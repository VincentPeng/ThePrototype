using UnityEngine;
using System.Collections;

public interface IEnemyState {

	void OnTriggerEnter2D(Collider2D col);

	void OnTriggerExit2D(Collider2D col);

	void UpdateState();

	void ToIdleState();

	void ToWalkState();

	void ToAttackState();
}
