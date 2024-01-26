using UnityEngine;


public class CameraBehaviour : MonoBehaviour{

	[SerializeField]
	Transform target;

	[SerializeField]
	Vector3 offset;

	[SerializeField]
	float speed;


	void LateUpdate(){
		Vector3 newPos = Vector3.Lerp(transform.position, target.position+offset, Time.deltaTime * speed); 
		transform.position = newPos; 
	}
}
