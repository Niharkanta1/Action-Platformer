using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       05-02-2022 18:15:16
================================================================*/
namespace DWG.AI {
    
    public class AIPlayerDetector : MonoBehaviour {

        public bool PlayerDetected { get; private set; }
        public Vector2 detectorSize = Vector2.one;
        public Vector2 detectorOriginOffset  = Vector2.zero;
        public float detectionDelay = 0.3f;
        public LayerMask detectorLayerMask;

        private GameObject _target;
        [SerializeField]
        private Transform detectorOrigin;
        
        [Header("Gizmo Parameters:")]
        public Color gizmoIdleColor = Color.green;
        public Color gizmoDetectedColor = Color.red;
        public bool showGizmos = true;

        public GameObject Target {
            get => _target;
            private set {
                _target = value;
                PlayerDetected = _target != null;
            }
        }

        private void Start() {
            StartCoroutine(DetectionCoroutine());
        }

        private IEnumerator DetectionCoroutine() {
            yield return new WaitForSeconds(detectionDelay);
            Collider2D collider = Physics2D.OverlapBox((Vector2) detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);
            Target = collider != null ? collider.gameObject : null;

            StartCoroutine(DetectionCoroutine());
        }
        
        public Vector2 DirectionToTarget() {
            return _target.transform.position - detectorOrigin.position;
        }

        private void OnDrawGizmos() {
            if (!showGizmos || detectorOrigin == null) return;
            Gizmos.color = gizmoIdleColor;
            if (PlayerDetected) {
                Gizmos.color = gizmoDetectedColor;
            }
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }

}