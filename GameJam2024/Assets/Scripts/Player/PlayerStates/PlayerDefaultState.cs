using UnityEngine;



public class PlayerDefaultState : PlayerBaseState{
	
	public override void EnterState(PlayerBehaviour behaviour){
		behaviour.spriteBopComponent.ExitBop();
	}

	public override void UpdateState(PlayerBehaviour behaviour){
		
	}

    public override void Move(PlayerBehaviour behaviour, Vector2 direction)
    {
		behaviour.SwitchState(behaviour.moveingState);
		behaviour.moveingState.Move(behaviour,direction);
	}
}

