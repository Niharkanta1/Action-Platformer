using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovementState {
    
    private bool _jumpPressed = false;
    
    protected override void EnterState() {
        Agent.animationManager.PlayAnimation(AnimationType.Jump);
        movementData.currentVelocity = Agent.rb.velocity;
        movementData.currentVelocity.y = Agent.agentData.jumpForce;
        Agent.rb.velocity = movementData.currentVelocity;
        _jumpPressed = true;
    }

    protected override void HandleJumpPressed() {
        _jumpPressed = true;
    }

    protected override void HandleJumpReleased() {
        _jumpPressed = false;
    }

    public override void StateUpdate() {
        ControlJumpHeight();
        CalculateVelocity();
        SetPlayerVelocity();
        if (Agent.rb.velocity.y <= 0) {
            Agent.TransitionToState(fallState);
        } else if (Agent.climbingDetector.CanClimb && Mathf.Abs(Agent.agentInput.MovementVector.y) > 0) {
            Agent.TransitionToState(climbState);
        }
    }

    private void ControlJumpHeight() {
        if (_jumpPressed == false) {
            movementData.currentVelocity = Agent.rb.velocity;
            movementData.currentVelocity.y += Agent.agentData.lowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
            Agent.rb.velocity = movementData.currentVelocity;
        }
    }
}
