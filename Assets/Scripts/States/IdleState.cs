using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;

public class IdleState : State {
    
    protected override void EnterState() {
        Agent.animationManager.PlayAnimation(AnimationType.Idle);
        if (Agent.groundDetector.isGrounded) {
            Agent.rb.velocity = Vector2.zero;
        }
    }

    protected override void HandleMovement(Vector2 input) {

        if (Agent.climbingDetector.CanClimb && Mathf.Abs(input.y) > 0) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Climb));
        } else if (Mathf.Abs(input.x) > 0) { 
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Move));
        }
    }
}
