using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionDeadState : LionBaseState{
    public override void EnterState(LionBehaviour behaviour)
    {
        behaviour.spriteRenderer.sprite = behaviour.lionDeadTexture;
		behaviour.rigidbody.velocity = Vector2.zero;
		behaviour.audioSource.clip = behaviour.clips[Random.Range(0,2)];
		behaviour.audioSource.Play();
		behaviour.StopAllCoroutines();
		behaviour.rigidbody.angularVelocity = 0;
		behaviour.rigidbody.velocity = Vector2.zero;
		behaviour.rigidbody.bodyType = RigidbodyType2D.Static;
    }
}
