using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionDeadState : LionBaseState{
    public override void EnterState(LionBehaviour behaviour)
    {
        behaviour.spriteRenderer.sprite = behaviour.lionDeadTexture;
    }
}
