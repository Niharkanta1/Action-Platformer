using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State {

    [SerializeField] protected State idleState;
    private float _previousGravityScale = 0;

    protected override void EnterState() {
        Agent.animationManager.PlayAnimation(AnimationType.Climb);
        Agent.animationManager.StopAnimation();
        _previousGravityScale = Agent.rb.gravityScale;
        Agent.rb.gravityScale = 0;
        Agent.rb.velocity  = Vector2.zero;
    }

    protected override void HandleJumpPressed() {
        Agent.TransitionToState(jumpState);
    }

    public override void StateUpdate() {
        if (Agent.agentInput.MovementVector.magnitude > 0) {
            Agent.animationManager.StartAnimation();
            Agent.rb.velocity = new Vector2(Agent.agentInput.MovementVector.x * Agent.agentData.climbHorizontalSpeed,
                Agent.agentInput.MovementVector.y * Agent.agentData.climbVerticalSpeed);
        } else {
            Agent.animationManager.StopAnimation();
            Agent.rb.velocity = Vector2.zero;
        }
        if (Agent.climbingDetector.CanClimb == false || (Agent.groundDetector.isGrounded && Agent.agentInput.MovementVector.y < 0)) {
            Agent.TransitionToState(idleState);
        }
    }

    protected override void ExitState() {
        Agent.rb.gravityScale = _previousGravityScale;
        Agent.animationManager.StartAnimation();
    }
}
