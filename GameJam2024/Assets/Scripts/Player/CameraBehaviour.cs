using UnityEngine;


public class CameraBehaviour : MonoBehaviour{

	[SerializeField]
	Transform target;

	[SerializeField]
	Vector3 offset;

	[SerializeField]
	float speed;
	

	[SerializeField]
	float cameraMaxScale, cameraMinScale;
	float cameraSize;
	new Camera camera;

	void Start(){
		camera = GetComponent<Camera>();
	}

	void LateUpdate(){
		Vector3 newPos = Vector3.Lerp(transform.position, target.position+offset, Time.deltaTime * speed); 
		transform.position = newPos;
		camera.orthographicSize = cameraSize;	
	}



	public void scaleCameraBasedOnMovement(Vector3 direction){
		if(direction.magnitude > .8f){
			cameraSize = Mathf.Lerp(cameraSize, cameraMaxScale, Time.deltaTime);
		}else{
			cameraSize = Mathf.Lerp(cameraSize, cameraMinScale, Time.deltaTime);
		}
	}
}
