using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehaviour : MonoBehaviour
{

	PlayerBaseState currentState;
	PlayerDefaultState defaultState;


    void Start()
    {
		defaultState = new PlayerDefaultState();
		currentState = defaultState;
    }

    void Update()
    {
        
    }
	
	public void LookAt(Vector2 point){
		float angle = Mathf.Atan2(point.x,point.y);
		angle *= Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
	}

	public void OnLook(InputValue callback){
		Vector2 lookDirection = callback.Get<Vector2>();
		currentState.Look(this, lookDirection);	
	}

	public void OnMove(InputValue callback){
		Vector2 movementDirection = callback.Get<Vector2>();
		currentState.Move(this, movementDirection);
	}

	public void OnFire(){
		currentState.Fire(this);
	}


}
