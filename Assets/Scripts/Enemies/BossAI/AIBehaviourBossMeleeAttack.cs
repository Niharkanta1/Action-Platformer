using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-04-2022 20:49:31
================================================*/
    
namespace DWG.AI {
    public class AIBehaviourBossMeleeAttack : AIBehaviour {

        [SerializeField]
        private AIDataBoard aiBoard;

        public override void PerformAction(AIEnemy enemyAI) {
            enemyAI.MovementVector = Vector2.zero;
            enemyAI.CallAttack(); 

            aiBoard.SetBoard(AIDataTypes.Arrived, true);
            aiBoard.SetBoard(AIDataTypes.Waiting, true);

        }
    }
}