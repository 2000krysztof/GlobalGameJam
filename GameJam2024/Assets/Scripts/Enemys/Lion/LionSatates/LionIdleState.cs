using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionIdleState : LionBaseState{

	public override void PlayerDetected(LionBehaviour behaviour, PlayerBehaviour player){
		behaviour.agroState.SetPlayer(player);
		behaviour.switchState(behaviour.agroState);
	}
}
