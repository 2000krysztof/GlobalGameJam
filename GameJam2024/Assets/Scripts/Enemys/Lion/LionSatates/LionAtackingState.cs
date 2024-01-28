using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAtackingState : LionBaseState{
    public override void EnterState(LionBehaviour behaviour)
    {
		behaviour.spriteRenderer.sprite = behaviour.lionAttackTexture;
		behaviour.rigidbody.velocity *= behaviour.chrageSpeed;
		behaviour.StartCoroutine(exitTimer(behaviour));
	}


	IEnumerator exitTimer(LionBehaviour behaviour){
		yield return new WaitForSecondsRealtime(2);
		behaviour.switchState(behaviour.agroState);
	}



    public override void HasCollided(LionBehaviour behaviour, IDamageable damageable)
    {
        damageable.takeDamage(2);
    }
}
