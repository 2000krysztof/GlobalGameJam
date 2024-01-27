using System.Collections;
using UnityEngine;



public class PlayerMoveingState : PlayerBaseState{
	
	 
	public override void UpdateState(PlayerBehaviour behaviour){
	
		behaviour.spriteBopComponent.Update();	

        if(behaviour.rigidBody.velocity.magnitude == 0){behaviour.SwitchState(behaviour.defaultState);}
	}

    public override void Move(PlayerBehaviour behaviour, Vector2 direction)
    {
		behaviour.rigidBody.velocity = direction;
		base.Move(behaviour, direction);
    }



}

