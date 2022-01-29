using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

public abstract class State : MonoBehaviour {
    protected Agent Agent;
    public UnityEvent onEnter, onExit;

    public void Initialize(Agent agent) {
        Agent = agent;
    }

    public void Enter() {
        Agent.agentInput.OnAttack += HandleAttack;
        Agent.agentInput.OnJumpPressed += HandleJumpPressed;
        Agent.agentInput.OnJumpReleased += HandleJumpReleased;
        Agent.agentInput.OnMovement += HandleMovement;
        onEnter?.Invoke();
        EnterState();
    }

    protected virtual void EnterState() {
    }

    protected virtual void HandleMovement(Vector2 input) {
    }

    protected virtual void HandleJumpReleased() {
    }

    protected virtual void HandleJumpPressed() {
        TestJumpTransition();
    }

    private void TestJumpTransition() {
        if (Agent.groundDetector.isGrounded) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Jump));
        }
    }

    protected virtual void HandleAttack() {
        TestAttackTransition();
    }

    private void TestAttackTransition() {
        if (Agent.agentWeapon.CanIUseWeapon(Agent.groundDetector.isGrounded)) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Attack));
        }
    }

    public virtual void StateUpdate() {
        TestFallTransition();
    }

    protected bool TestFallTransition() {
        if (Agent.groundDetector.isGrounded == false) {
            Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Fall));
            return true;
        }

        return false;
    }
    
    public virtual void StateFixedUpdate() {
    }

    public virtual void Die() {
        Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Die));
    }
    
    public void Exit() {
        Agent.agentInput.OnAttack -= HandleAttack;
        Agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        Agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        Agent.agentInput.OnMovement -= HandleMovement;
        onExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState() {
    }

    public virtual void GetHit() {
        Agent.TransitionToState(Agent.stateFactory.GetState(StateType.Hit));
    }
}
