using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAgroState : LionBaseState{

	PlayerBehaviour player;

	public void SetPlayer(PlayerBehaviour playerBehaviour){
		player = playerBehaviour;
		
	}

	public override void UpdateState(LionBehaviour behaviour){
		behaviour.LookAt(player.transform.position);
		behaviour.spriteBop.Update();
		Transform transform = behaviour.transform;
		behaviour.Move(transform, player.transform.position);

	}

	


}
