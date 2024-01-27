using UnityEngine;

public abstract class PlayerBaseState{

	protected static Vector3 moveDirection = Vector3.zero;

	public virtual void EnterState(PlayerBehaviour behaviour){
		if(behaviour.hasHammer){
			behaviour.playerSpriteRender.sprite = behaviour.hasHammerTexture;
		}else{
			behaviour.playerSpriteRender.sprite = behaviour.defaultTexture;
		}
	}
	public virtual void UpdateState(PlayerBehaviour behaviour){
		
	}

	public virtual void Move(PlayerBehaviour behaviour,Vector2 direction){
		
	}
	 

	public virtual void Fire(PlayerBehaviour behaviour){
		if(!behaviour.hasHammer){return;}
		behaviour.SwitchState(behaviour.atackingState);
	}
	
	public virtual void Interact(PlayerBehaviour behaviour){

	}
	
	public virtual void Look(PlayerBehaviour behaviour, Vector2 direction){
		direction = (Vector2)Camera.main.ScreenToWorldPoint(direction);
		behaviour.LookAt(direction);
	}



}
