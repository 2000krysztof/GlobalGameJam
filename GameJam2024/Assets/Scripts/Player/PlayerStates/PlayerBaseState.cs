using UnityEngine;

public abstract class PlayerBaseState{

	public virtual void EnterState(PlayerBehaviour behaviour){
		
	}
	public virtual void UpdateState(PlayerBehaviour behaviour){

	}

	public virtual void Move(PlayerBehaviour behaviour,Vector2 direction){
		
	}

	public virtual void Fire(PlayerBehaviour behaviour){

	}
	public virtual void Interact(PlayerBehaviour behaviour){

	}
	public virtual void Look(PlayerBehaviour behaviour, Vector2 direction){
		behaviour.LookAt(direction);
	}
}
