using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 23:07:58
================================================================*/

public class HitState : State {
    
    protected override void EnterState() {
        Agent.animationManager.PlayAnimation(AnimationType.Hit);
        Agent.animationManager.onAnimationEnd.AddListener(TransitionToIdle);
    }

    protected override void HandleAttack() {
        // Prevent this
    }

    protected override void HandleJumpPressed() {
        // Prevent this
    }

    protected override void HandleJumpReleased() {
        // Prevent this
    }

    protected override void HandleMovement(Vector2 input) {
        // Prevent this
    }

    public override void StateUpdate() {
        // Prevent this
    }

    public override void GetHit() {
        // Prevent this
    }

    private void TransitionToIdle() {
        Agent.animationManager.onAnimationEnd.RemoveListener(TransitionToIdle);
        Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Idle));
    }

    protected override void ExitState() {
        base.ExitState();
    }
}
