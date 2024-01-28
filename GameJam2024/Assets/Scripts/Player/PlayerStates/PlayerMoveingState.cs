using System.Collections;
using UnityEngine;



public class PlayerMoveingState : PlayerBaseState{

    public override void EnterState(PlayerBehaviour behaviour)
    {
		Sprite sprite = behaviour.hasHammer? behaviour.hasHammerTexture : behaviour.defaultTexture;
		behaviour.playerSpriteRender.sprite = sprite; 
    }
     
	public override void UpdateState(PlayerBehaviour behaviour){
	
		behaviour.spriteBopComponent.Update();	

        if(behaviour.rigidBody.velocity.magnitude == 0){behaviour.SwitchState(behaviour.defaultState);}
	}

    public override void Move(PlayerBehaviour behaviour, Vector2 direction)
    {
		behaviour.rigidBody.velocity = direction  ;
    }



}

