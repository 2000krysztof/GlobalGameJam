using System.Collections;
using UnityEngine;

public class LionAgroState : LionBaseState{

	PlayerBehaviour player;
	bool canAttack = false;

	public void SetPlayer(PlayerBehaviour playerBehaviour){
		player = playerBehaviour;
	}
    public override void EnterState(LionBehaviour behaviour)
    {
        behaviour.StartCoroutine(attackCooldown());
		behaviour.spriteRenderer.sprite = behaviour.lionDefaultTexture;
		MonoBehaviour.Destroy(behaviour.detectionRadius);
    }

    

	public override void UpdateState(LionBehaviour behaviour){
		behaviour.LookAt(player.transform.position);
		behaviour.spriteBop.Update();
		Transform transform = behaviour.transform;
		behaviour.Move(transform, player.transform.position);
		TryAttackPlayer(behaviour);
	}

	void TryAttackPlayer(LionBehaviour behaviour){
		float dist = Vector3.Distance(behaviour.transform.position, player.transform.position);
		if(canAttack && dist<behaviour.attackDistance)
			Attack(behaviour);
	}

	void Attack(LionBehaviour behaviour){
		canAttack = false;
		behaviour.switchState(behaviour.atackingState);
		behaviour.StartCoroutine(attackCooldown());
	
	}

	IEnumerator attackCooldown(){
		yield return new WaitForSecondsRealtime(5);
		canAttack = true;
	}
}
