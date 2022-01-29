using System;
using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;
using UnityEngine.Events;

public class MovementState : State {
    
    [SerializeField]
    protected MovementData movementData;

    public UnityEvent onStep;

    private void Awake() {
        movementData = GetComponentInParent<MovementData>();
    }

    protected override void EnterState() {
        base.EnterState();
        Agent.animationManager.PlayAnimation(AnimationType.Run);
        Agent.animationManager.onAnimationAction.AddListener(() => onStep.Invoke());
        movementData.horizontalMovementDirection = 0;
        movementData.currentSpeed = 0;
        movementData.currentVelocity = Vector2.zero;
    }

    protected override void ExitState() {
        Agent.animationManager.ResetEvents();
    }

    public override void StateUpdate() {
        if (TestFallTransition()) {
            return;
        }
        CalculateVelocity();
        SetPlayerVelocity();
        if (Mathf.Abs(Agent.rb.velocity.x) < 0.01f) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Idle));
        } else if (Agent.climbingDetector.CanClimb && Mathf.Abs(Agent.agentInput.MovementVector.y) > 0) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Climb));
        }
    }

    protected void SetPlayerVelocity() {
        Agent.rb.velocity = movementData.currentVelocity;
    }

    protected void CalculateVelocity() {
        CalculateSpeed(Agent.agentInput.MovementVector, movementData);
        CalculateHorizontalDirection(movementData);
        movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
        movementData.currentVelocity.y = Agent.rb.velocity.y;
    }

    protected void CalculateHorizontalDirection(MovementData data) {
        if (Agent.agentInput.MovementVector.x > 0) {
            data.horizontalMovementDirection = 1;
        } else if (Agent.agentInput.MovementVector.x < 0) {
            data.horizontalMovementDirection = -1;
        }
    }

    protected void CalculateSpeed(Vector2 movementVector, MovementData data) {
        if (Mathf.Abs(movementVector.x) > 0) {
            data.currentSpeed += Agent.agentData.acceleration * Time.deltaTime;
        } else {
            data.currentSpeed -= Agent.agentData.deAcceleration * Time.deltaTime;
        }

        data.currentSpeed = Mathf.Clamp(data.currentSpeed, 0, Agent.agentData.maxSpeed);
    }
}
