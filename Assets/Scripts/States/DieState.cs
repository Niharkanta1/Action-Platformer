using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 00:00:34
================================================================*/

public class DieState : State {
    
    [SerializeField]
    private float timeToWaitBeforeDieAction = 2;
    
    protected override void EnterState() {
        Agent.animationManager.PlayAnimation(AnimationType.Die);
        //Agent.rb.velocity = Vector2.zero;
        Agent.animationManager.onAnimationEnd.AddListener(WaitBeforeDieAction);
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
    
    protected override void HandleAttack() {
        // Prevent this
    }

    public override void StateUpdate() {
        Agent.rb.velocity = new Vector2(0, Agent.rb.velocity.y);
    }
    
    public override void Die() {
        // Prevent this
    }

    private void WaitBeforeDieAction() {
        Agent.animationManager.onAnimationEnd.RemoveListener(WaitBeforeDieAction);
        StartCoroutine(WaitCoroutine());
    }   

    private IEnumerator WaitCoroutine() {
        yield return new WaitForSeconds(timeToWaitBeforeDieAction);
        Agent.OnAgentDie?.Invoke();
    }

    protected override void ExitState() {
        StopAllCoroutines();
        Agent.animationManager.ResetEvents();
    }
}
