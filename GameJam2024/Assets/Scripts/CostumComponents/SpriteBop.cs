using UnityEngine;


public class SpriteBop{
	Transform transform;
	float scaleOffset = 0;
	public float bopSpeed {get ; set;}
	public float bopSize {get; set;}



	Vector3 originalScale,
			newScale,
			offsetScale = Vector3.one ;


	public SpriteBop(Transform transform, float bopSpeed, float bopSize){
		this.transform = transform;
		originalScale = transform.localScale;
		this.bopSize = bopSize;
		this.bopSpeed = bopSpeed;
		
	}

	public void Update(){
		newScale = originalScale * scaleOffset * bopSize + offsetScale;
		scaleOffset = Mathf.Sin(Time.time* bopSpeed);
		transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime);
	}
	
	public void ExitBop(){
		transform.localScale = originalScale;
	}
	
}
