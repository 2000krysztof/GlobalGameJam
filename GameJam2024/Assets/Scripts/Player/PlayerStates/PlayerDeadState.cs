using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public override void EnterState(PlayerBehaviour behaviour)
    {
        behaviour.playerSpriteRender.sprite = behaviour.deadTexture;
		behaviour.rigidBody.velocity = Vector2.zero;
    }
    
	public override void UpdateState(PlayerBehaviour behaviour){}	

	public override void Move(PlayerBehaviour behaviour,Vector2 direction){
	}

	public override void Fire(PlayerBehaviour behaviour){
	}
	
	public override void Interact(PlayerBehaviour behaviour){
	}
	
	public override void Look(PlayerBehaviour behaviour, Vector2 direction){
	}
}
