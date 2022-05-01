using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-04-2022 20:49:13
================================================*/
    
namespace DWG.AI {
    public class AIBehaviourBossWait : AIBehaviour {

        [SerializeField] private AIDataBoard aiDataBoard;
        [SerializeField] private float waitTime = 0.5f;

        public override void PerformAction(AIEnemy enemyAI) {
            enemyAI.MovementVector = Vector2.zero;
            StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine() {
            yield return new WaitForSeconds(waitTime);
            aiDataBoard.SetBoard(AIDataTypes.Waiting, false);
        }
    }
}