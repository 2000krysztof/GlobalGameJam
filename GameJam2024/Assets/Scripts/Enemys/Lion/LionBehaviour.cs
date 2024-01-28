using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionBehaviour : MonoBehaviour, IDamageable
{
	LionBaseState currentState;
	
	public LionIdleState idleState = new LionIdleState();	
	public LionAgroState agroState = new LionAgroState();
	public LionDeadState deadState = new LionDeadState();
	public LionAtackingState atackingState = new LionAtackingState();

	public
	float health,
		  moveSpeed,
		  chrageSpeed,
		  attackDistance,
		  bopSpeed,
		  bopHeight;

	public	SpriteBop spriteBop;

	public Sprite lionDefaultTexture,
					lionAttackTexture,
					lionDeadTexture;

	public AudioSource audioSource;
	public AudioClip[] clips;
	

	public Collider2D detectionRadius;

	public new Rigidbody2D rigidbody;
	public SpriteRenderer spriteRenderer;
	

	void Start()
    {
		spriteBop = new SpriteBop(transform, bopSpeed,bopHeight);
		spriteRenderer = GetComponent<SpriteRenderer>();
		currentState = idleState;
		rigidbody = GetComponent<Rigidbody2D>();
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
		LookAt(playerPosition);
		rigidbody.velocity = transform.up*moveSpeed;
	}

	public void takeDamage(float damage){
		health -= damage;
		if(health <= 0){switchState(deadState);}
	}

	void OnTriggerEnter2D(Collider2D col){
		PlayerBehaviour player;
		if(col.TryGetComponent<PlayerBehaviour>(out player)){
			currentState.PlayerDetected(this, player);			
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		IDamageable damageable;
		if(coll.gameObject.TryGetComponent<IDamageable>(out damageable)){
			currentState.HasCollided(this, damageable);
		}
	}
}
