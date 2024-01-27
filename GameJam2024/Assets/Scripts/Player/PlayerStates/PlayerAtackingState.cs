using System.Collections;
using UnityEngine;

public class PlayerAtackingState : PlayerMoveingState 
{
	public override void EnterState(PlayerBehaviour behaviour){
		
		behaviour.playerSpriteRender.sprite = behaviour.isAttackingTexture;
		behaviour.StartCoroutine(attackTimer(behaviour, moveDirection));
	}

	IEnumerator attackTimer(PlayerBehaviour behaviour, Vector2 direction){
		yield return new WaitForSeconds(0.4f);
		behaviour.SwitchState(behaviour.moveingState);
	}
}
