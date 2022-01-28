using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour {

    public Collider2D agentCollider;
    public LayerMask groundMask;
    public bool isGrounded = false;

    [Header("Gizmo Parameters:")] 
    [Range(-2f, 2f)]
    public float boxCastYOffset = -0.1f;
    [Range(-2f, 2f)]
    public float boxCastXOffset = -0.1f;

    [Range(0, 2)] public float boxCastWidth = 1, boxCastHeight = 1;
    public Color gizmoColorNotGrounded = Color.red, gizmoColorGrounded = Color.green;

    private void Awake() {
        if (agentCollider == null) {
            agentCollider = GetComponent<Collider2D>();
        }
    }

    public void CheckIfGrounded() {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(agentCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0), 
            new Vector2(boxCastWidth, boxCastHeight),
            0, 
            Vector2.down, 
            0, 
            groundMask);

        if (rayCastHit.collider != null) {
            if (rayCastHit.collider.IsTouching(agentCollider)) { // For platforms
                isGrounded = true;
            }
        } else {
            isGrounded = false;
        }

    }

    private void OnDrawGizmos() {
        if (agentCollider == null) {
            return;
        }

        Gizmos.color = gizmoColorNotGrounded;
        if (isGrounded)
            Gizmos.color = gizmoColorGrounded;
        
        Gizmos.DrawWireCube(agentCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
            new Vector3(boxCastWidth, boxCastHeight));
    }
}
