using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 20:06:13
================================================================*/
namespace DWG.AI {

    public class AIEndPlatformDetector : MonoBehaviour {

        public BoxCollider2D detectorCollider;
        public LayerMask groundMask;
        [Range(0, 2)] public float groundRaycastLength = 2;

        [Range(0, 1)] public float groundRaycastDelay = 0.1f;
        public bool PathBlocked { get; private set; }
        public event Action OnPathBlocked;
        
        [Header("Gizmo Parameters:")]
        public Color colliderColor = Color.magenta;
        public Color groundRayCastColor = Color.blue;
        public bool showGizmos = true;
        
        // Wall Check
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.layer == LayerMask.NameToLayer("ClimbingStuff"))
                return;
            OnPathBlocked?.Invoke();
        }
        
        private void Start() {
            StartCoroutine(CheckGroundCoroutine());
        }

        // End of Ground/Platform Check
        private IEnumerator CheckGroundCoroutine() {    
            yield return new WaitForSeconds(groundRaycastDelay);
            var hit = Physics2D.Raycast(detectorCollider.bounds.center, Vector2.down, groundRaycastLength, groundMask);
            if (hit.collider == null) { 
                OnPathBlocked?.Invoke();
            }

            PathBlocked = hit.collider == null;
            StartCoroutine(CheckGroundCoroutine());
        }

        private void OnDrawGizmos() {
            if (!showGizmos || detectorCollider == null) return;
            Gizmos.color = groundRayCastColor;
            var colliderBounds = detectorCollider.bounds;
            Gizmos.DrawRay(colliderBounds.center, Vector2.down * groundRaycastLength);
            Gizmos.color = colliderColor;
            Gizmos.DrawCube(colliderBounds.center, colliderBounds.size);
        }
    }
}
