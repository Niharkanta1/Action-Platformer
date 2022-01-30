using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;

public class FallState : MovementState {

    protected override void EnterState() {
        Agent.animationManager.PlayAnimation(AnimationType.Fall);
    }

    protected override void HandleJumpPressed() {
        // Don't allow jumping in fall state
    }

    public override void StateUpdate() {
        movementData.currentVelocity = Agent.rb.velocity;
        movementData.currentVelocity.y += Agent.agentData.gravityModifier * Physics2D.gravity.y * Time.deltaTime;
        Agent.rb.velocity = movementData.currentVelocity;
        CalculateVelocity();
        SetPlayerVelocity();
        if (Agent.groundDetector.isGrounded) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Idle));
        } else if (Agent.climbingDetector.CanClimb && Mathf.Abs(Agent.AgentInput.MovementVector.y) > 0) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Climb));
        }
    }
}
