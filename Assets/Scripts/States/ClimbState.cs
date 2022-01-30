using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;

public class ClimbState : State {

    private float _previousGravityScale = 0;

    protected override void EnterState() {
        Agent.animationManager.PlayAnimation(AnimationType.Climb);
        Agent.animationManager.StopAnimation();
        _previousGravityScale = Agent.rb.gravityScale;
        Agent.rb.gravityScale = 0;
        Agent.rb.velocity  = Vector2.zero;
    }

    protected override void HandleJumpPressed() {
        Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Jump));
    }

    public override void StateUpdate() {
        if (Agent.AgentInput.MovementVector.magnitude > 0) {
            Agent.animationManager.StartAnimation();
            Agent.rb.velocity = new Vector2(Agent.AgentInput.MovementVector.x * Agent.agentData.climbHorizontalSpeed,
                Agent.AgentInput.MovementVector.y * Agent.agentData.climbVerticalSpeed);
        } else {
            Agent.animationManager.StopAnimation();
            Agent.rb.velocity = Vector2.zero;
        }
        if (Agent.climbingDetector.CanClimb == false || (Agent.groundDetector.isGrounded && Agent.AgentInput.MovementVector.y < 0)) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Idle));
        }
    }

    protected override void ExitState() {
        Agent.rb.gravityScale = _previousGravityScale;
        Agent.animationManager.StartAnimation();
    }

    protected override void HandleAttack() {
        // Prevent attack
    }
}
