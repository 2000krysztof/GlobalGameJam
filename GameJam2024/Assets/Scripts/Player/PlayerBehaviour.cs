using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehaviour : MonoBehaviour
{
    void Start()
    {
			        
    }

    void Update()
    {
        
    }

	void OnMove(InputValue callback){
		Vector2 movementDirection = callback.Get<Vector2>();
		print(movementDirection);

	}
}
