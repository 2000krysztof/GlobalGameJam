using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LionBaseState{

	public virtual void EnterState(LionBehaviour behaviour){

	}
	public virtual void UpdateState(LionBehaviour behaviour){
	
	}

	public virtual void PlayerDetected(LionBehaviour behaviour, PlayerBehaviour player){
				
	}
}
