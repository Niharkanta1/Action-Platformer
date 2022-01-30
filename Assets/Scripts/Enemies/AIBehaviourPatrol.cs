using System;
using System.Collections;
using System.Collections.Generic;
using DWG.AI;
using UnityEngine;
using Random = UnityEngine.Random;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 20:03:38
================================================================*/
namespace DWG.AI {
    
    public class AIBehaviourPatrol : AIBehaviour {

        public AIEndPlatformDetector aiEndPlatformDetector; 
        private Vector2 _movementVector = Vector2.zero;

        private void Awake() {
            if (aiEndPlatformDetector == null) {
                aiEndPlatformDetector = GetComponentInChildren<AIEndPlatformDetector>();
            }
        }

        private void Start() {
            aiEndPlatformDetector.OnPathBlocked += HandlePathBlocked;
            _movementVector = new Vector2(Random.value > 0.5f ? 1 : -1, 0);
        }

        private void HandlePathBlocked() {
            _movementVector *= new Vector2(-1, 0);
        }

        public override void PerformAction(AIEnemy enemyAI) {
            enemyAI.MovementVector = _movementVector;
            enemyAI.CallOnMovement(_movementVector);
        }
    }
}
