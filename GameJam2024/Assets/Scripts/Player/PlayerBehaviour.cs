using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehaviour : MonoBehaviour
{
	PlayerBaseState currentState;
	PlayerDefaultState defaultState;


	[SerializeField]
	float moveSpeed =10;
	CameraBehaviour cameraBehaviour;

    void Start()
    {
		defaultState = new PlayerDefaultState();
		currentState = defaultState;
		currentState.EnterState(this);
		cameraBehaviour = Camera.main.transform.GetComponent<CameraBehaviour>();
    }

    void Update()
    {
        currentState.UpdateState(this);
    }
	
	public void LookAt(Vector2 point){
		Vector2 difference = (Vector2)transform.position - point;
		float angle = Mathf.Atan2(difference.y,difference.x)+ Mathf.PI*0.5f; 
		angle *= Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
	}

	public void Move(Vector3 direction){
		transform.position += direction*moveSpeed*Time.deltaTime;
		cameraBehaviour.scaleCameraBasedOnMovement(direction);	
			
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

	public void SwitchState(PlayerBaseState state){
		currentState = state;
		state.EnterState(this);
	}
}
