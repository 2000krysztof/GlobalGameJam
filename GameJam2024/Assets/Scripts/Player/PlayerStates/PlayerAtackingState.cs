using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtackingState : PlayerMoveingState 
{
	public override void EnterState(PlayerBehaviour behaviour){
		behaviour.audioSource.Play();	
		behaviour.playerSpriteRender.sprite = behaviour.isAttackingTexture;
		behaviour.StartCoroutine(attackTimer(behaviour, moveDirection));
		checkDamage(behaviour);
	}

    public override void Fire(PlayerBehaviour behaviour){}

	public override void UpdateState(PlayerBehaviour behaviour){
        if(!(behaviour.rigidBody.velocity.magnitude == 0)){
			behaviour.spriteBopComponent.Update();	
		}
	}
    

	IEnumerator attackTimer(PlayerBehaviour behaviour, Vector2 direction){
		yield return new WaitForSeconds(1f);
		//This is not my finest code but I was short on time and it works so I dont care
		if(!(behaviour.playerSpriteRender.sprite == behaviour.deadTexture)){			
			behaviour.SwitchState(behaviour.moveingState);
		}

	}


	void checkDamage(PlayerBehaviour behaviour){
		Collider2D[] results = Physics2D.OverlapCircleAll(behaviour.damageArea.position, 0.5f, 1);
		foreach(Collider2D collider in results){
			IDamageable damageable;
			if(collider.transform.TryGetComponent<IDamageable>(out damageable)){
				if(damageable == behaviour){continue;}
				damageable.takeDamage(behaviour.hitStrength);
			}
		}
		
	}
}
