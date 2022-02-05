using System;
using System.Collections;
using System.Collections.Generic;
using DWG.AI;
using UnityEngine;
using UnityEngine.Serialization;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       05-02-2022 17:43:34
================================================================*/
namespace DFG.AI {

    public class AIBehaviourShoot : AIBehaviour {

        public AIPlayerDetector aiPlayerDetector;
        [SerializeField] private bool isWaiting;
        [SerializeField] private float delay = 1;

        public override void PerformAction(AIEnemy enemyAI) {
            if(isWaiting) return;
            if (aiPlayerDetector.PlayerDetected == false) return;
            enemyAI.CallOnMovement(aiPlayerDetector.DirectionToTarget());
            enemyAI.CallOnAttack();
            isWaiting = true;
            StartCoroutine(AttackDelayCoroutine());
        }
        
        private IEnumerator AttackDelayCoroutine() {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }
    }
}
