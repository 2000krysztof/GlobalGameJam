using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
	PlayerBaseState currentState;
	public PlayerDefaultState defaultState = new PlayerDefaultState();
	public PlayerMoveingState moveingState = new PlayerMoveingState();

	[SerializeField]
	float moveSpeed =10;
	CameraBehaviour cameraBehaviour;
	SpriteRenderer playerSpriteRender;
	
	[Header("Sprite Bop")]
	[SerializeField]
	float bopSpeed;
	[SerializeField]
	float bopScale;
	public SpriteBop spriteBopComponent;

    void Start()
    {
		cameraBehaviour = Camera.main.transform.GetComponent<CameraBehaviour>();
		playerSpriteRender = GetComponent<SpriteRenderer>();

		spriteBopComponent = new SpriteBop(transform,bopSpeed, bopScale);

		currentState = defaultState;
		currentState.EnterState(this);
    }

    void Update()
    {
		print(defaultState);
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
