using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 15:48:17
================================================================*/

public class AttackState : State {

    public LayerMask hittableLayerMask;

    public UnityEvent<AudioClip> onWeaponSound;

    private bool _showGizmos = false;
    private Vector3 _direction;
    
    protected override void EnterState() {
        Agent.animationManager.ResetEvents();
        Agent.animationManager.PlayAnimation(AnimationType.Attack);
        Agent.animationManager.onAnimationEnd.AddListener(TransitionToIdleState);
        Agent.animationManager.onAnimationAction.AddListener(PerformAttack);
        
        Agent.agentWeapon.ToggleWeaponVisibility(true);
        _direction = Agent.transform.right * (Agent.transform.localScale.x > 0 ? 1 : -1);
        if (Agent.groundDetector.isGrounded) {
            Agent.rb.velocity = Vector2.zero;
        }
    }

    private void PerformAttack() {
        onWeaponSound?.Invoke(Agent.agentWeapon.GetCurrentWeapon().weaponSwingSound);
        Agent.animationManager.onAnimationAction.RemoveListener(PerformAttack);
        Agent.agentWeapon.GetCurrentWeapon().PerformAttack(Agent, hittableLayerMask, _direction);
    }

    private void TransitionToIdleState() {
        Agent.animationManager.onAnimationEnd.RemoveListener(TransitionToIdleState);
        Agent.TransitionToState(Agent.groundDetector.isGrounded ? Agent.stateFactory.GetState(StateType.Idle) : Agent.stateFactory.GetState(StateType.Fall));
    }

    protected override void ExitState() { 
        Agent.animationManager.ResetEvents();
        Agent.agentWeapon.ToggleWeaponVisibility(false);
    }

    private void OnDrawGizmos() {
        if(Application.isPlaying == false || _showGizmos == false)
            return;
        Gizmos.color = Color.red;
        var pos = Agent.agentWeapon.transform.position;
        Agent.agentWeapon.GetCurrentWeapon().DrawWeaponGizmo(pos, _direction);
    }

    protected override void HandleAttack() {
        // Prevent attacking again
    }

    protected override void HandleJumpPressed() {
        // Prevent jumping
    }
    
    protected override void HandleJumpReleased() {
        // Prevent jumping
    }

    protected override void HandleMovement(Vector2 input) {
        // Stop Filp
    }

    public override void StateUpdate() {
        // Prevent Update
    }

    public override void StateFixedUpdate() {
        // Prevent Fixed Update
    }
}
