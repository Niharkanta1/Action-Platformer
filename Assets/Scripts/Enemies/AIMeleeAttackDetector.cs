using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 21:40:17
================================================================*/
namespace DWG.AI {
    
    public class AIMeleeAttackDetector : MonoBehaviour {

        public bool PlayerDetected { get; private set; }
        public LayerMask targetLayer;
        public UnityEvent<GameObject> onPlayerDetected;
        [Range(.1f, 1)] public float radius;
        
        [Header("Gizmo parameters:")]
        public Color gizmoColor = Color.green;
        public bool showGizmos = true;

        private void Update() {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
            PlayerDetected = collider != null;
            if(PlayerDetected) 
                onPlayerDetected?.Invoke(collider.gameObject);
        }

        private void OnDrawGizmos() {
            if (!showGizmos) return;
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}
