using UnityEngine;



public class PlayerMoveingState : PlayerBaseState{
	
	 
	public override void UpdateState(PlayerBehaviour behaviour){
		behaviour.Move(moveDirection);
		behaviour.spriteBopComponent.Update();	
	}

    public override void Move(PlayerBehaviour behaviour, Vector2 direction)
    {
        if(direction.magnitude == 0){behaviour.SwitchState(behaviour.defaultState);}
		base.Move(behaviour, direction);
    }
}

