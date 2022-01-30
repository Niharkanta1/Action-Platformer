using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 21:39:14
================================================================*/
namespace DWG.AI {

    public class AIBehaviourMeleeAttack : AIBehaviour {

        public AIMeleeAttackDetector meleeRangeDetector;
        [SerializeField] private bool isWaiting;
        [SerializeField] private float delay = 1;

        private void Awake() {
            if (meleeRangeDetector == null) {
                meleeRangeDetector = transform.parent.GetComponentInParent<AIMeleeAttackDetector>();
            }
        }
        
        public override void PerformAction(AIEnemy enemyAI) {
            if(isWaiting) return;
            if (meleeRangeDetector.PlayerDetected == false) return;
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
