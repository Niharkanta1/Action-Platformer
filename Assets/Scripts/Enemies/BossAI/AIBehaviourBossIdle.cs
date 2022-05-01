using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-04-2022 20:48:48
================================================*/
    
namespace DWG.AI {
    public class AIBehaviourBossIdle : AIBehaviour {
        public override void PerformAction(AIEnemy enemyAI) {
            enemyAI.MovementVector = Vector2.zero;
            enemyAI.CallOnMovement(Vector2.zero);
        }
    }
}