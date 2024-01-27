using UnityEngine;

public abstract class PlayerBaseState{

	protected Vector3 moveDirection = Vector3.zero;

	public virtual void EnterState(PlayerBehaviour behaviour){
	}
	public virtual void UpdateState(PlayerBehaviour behaviour){
		behaviour.Move(moveDirection);
	}

	public virtual void Move(PlayerBehaviour behaviour,Vector2 direction){
		moveDirection = (Vector3)direction;
	}

	public virtual void Fire(PlayerBehaviour behaviour){

	}
	public virtual void Interact(PlayerBehaviour behaviour){

	}
	public virtual void Look(PlayerBehaviour behaviour, Vector2 direction){
		direction = (Vector2)Camera.main.ScreenToWorldPoint(direction);
		behaviour.LookAt(direction);
	}


}
