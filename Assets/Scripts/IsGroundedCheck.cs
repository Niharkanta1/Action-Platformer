using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       28-01-2022 23:09:58
================================================================*/

public class IsGroundedCheck : MonoBehaviour {

    [SerializeField] private GroundDetector groundDetector;
    public UnityEvent onConditionValidAction;

    public void TryPerformingAction() {
        if (groundDetector.isGrounded) {
            onConditionValidAction?.Invoke();
        }
    }
    
}
