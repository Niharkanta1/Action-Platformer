using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 19:43:30
================================================================*/
namespace DWG.AI {

    public class AIPatrollingEnemyBrain : AIEnemy {
        public GroundDetector agentGroundDetector;
        public AIBehaviour attackBehaviour, patrolBehaviour;

        private void Awake() {
            if (agentGroundDetector == null)
                agentGroundDetector = GetComponentInChildren<GroundDetector>();
        }

        private void Update() {
            if (!agentGroundDetector.isGrounded) return;
            attackBehaviour.PerformAction(this);
            patrolBehaviour.PerformAction(this);
        }
    }
}
