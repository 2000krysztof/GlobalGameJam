using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour, IDamageable
{
	PlayerBaseState currentState;
	public PlayerDefaultState defaultState = new PlayerDefaultState();
	public PlayerMoveingState moveingState = new PlayerMoveingState();
	public PlayerAtackingState atackingState = new PlayerAtackingState();
	public PlayerDeadState deadState = new PlayerDeadState();


	[SerializeField]
	float moveSpeed =10,
	health = 100;
	

	CameraBehaviour cameraBehaviour;
	public SpriteRenderer playerSpriteRender;
	
	[Header("Sprite Bop")]
	[SerializeField]
	float bopSpeed;
	[SerializeField]
	float bopScale;
	public SpriteBop spriteBopComponent;

	public bool hasHammer = true;
	
	
	public Sprite defaultTexture,
					pickupTexture,
					hasHammerTexture,
					isAttackingTexture;

	public Rigidbody2D rigidBody;
	

    void Start()
    {
		rigidBody = GetComponent<Rigidbody2D>();
		cameraBehaviour = Camera.main.transform.GetComponent<CameraBehaviour>();
		playerSpriteRender = GetComponent<SpriteRenderer>();

		spriteBopComponent = new SpriteBop(transform,bopSpeed, bopScale);

		currentState = defaultState;
		currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
		cameraBehaviour.scaleCameraBasedOnMovement(rigidBody.velocity);
    }
	
	public void LookAt(Vector2 point){
		Vector2 difference = (Vector2)transform.position - point;
		float angle = Mathf.Atan2(difference.y,difference.x)+ Mathf.PI*0.5f; 
		angle *= Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
	}


	
	public void attack(){
		SwitchState(atackingState);	
}	



	public void takeDamage(float damage){
		health -= damage;
		//TODO make sure to switch state when this drops below 0;
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
		print(state);
		currentState = state;
		state.EnterState(this);
	}
}
