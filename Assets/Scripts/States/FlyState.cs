using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       13-03-2022 14:22:23
================================================================*/
    
public class FlyState : MovementState {
    
    protected Vector2 movementDirection;
    
    protected new void CalculateSpeed(Vector2 movementVector, MovementData data) {
        movementDirection = movementVector.normalized;
        if (Mathf.Abs(movementVector.magnitude) > 0) {
            data.currentSpeed += Agent.agentData.acceleration * Time.deltaTime;
        } else {
            data.currentSpeed -= Agent.agentData.deAcceleration * Time.deltaTime;
        }

        data.currentSpeed = Mathf.Clamp(data.currentSpeed, 0, Agent.agentData.maxSpeed);
    }
    
    protected new void CalculateVelocity() {    
        CalculateSpeed(Agent.AgentInput.MovementVector, movementData);
        CalculateHorizontalDirection(movementData);
        movementData.currentVelocity = movementDirection * movementData.currentSpeed;
    }
    
    public override void StateUpdate() {
        CalculateVelocity();
        SetPlayerVelocity();
    }
}
