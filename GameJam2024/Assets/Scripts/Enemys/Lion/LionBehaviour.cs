using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionBehaviour : MonoBehaviour
{
	LionBaseState currentState;
	
	public LionIdleState idleState = new LionIdleState();	
	public LionAgroState agroState = new LionAgroState();
	public LionDeadState deadState = new LionDeadState();
	public LionAtackingState atackingState = new LionAtackingState();

	[SerializeField]
	float health,
		  moveSpeed,
		  bopSpeed,
		  bopHeight;

	public	SpriteBop spriteBop;	
    

	void Start()
    {
		spriteBop = new SpriteBop(transform, bopSpeed,bopHeight);

	

		currentState = idleState;
		
    }

    void Update()
    {
		currentState.UpdateState(this); 
    }

	public void switchState(LionBaseState state){
		currentState = state;
		currentState.EnterState(this);

	}

	public void LookAt(Vector2 point){
		Vector2 difference = (Vector2)transform.position - point;
		float angle = Mathf.Atan2(difference.y,difference.x)+ Mathf.PI*0.5f; 
		angle *= Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
	}


	public void Move(Transform transform, Vector2 playerPosition){
		transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime*moveSpeed);
	}



	void OnTriggerEnter2D(Collider2D col){
		PlayerBehaviour player;
		if(col.TryGetComponent<PlayerBehaviour>(out player)){
			currentState.PlayerDetected(this, player);			
		}
	}

}
