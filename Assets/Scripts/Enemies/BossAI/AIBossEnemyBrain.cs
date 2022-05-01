using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-04-2022 20:30:38
================================================*/
    
namespace DWG.AI {
    public class AIBossEnemyBrain : AIEnemy {

        [SerializeField]
        private AIDataBoard aiBoard;
        [SerializeField]
        private AIPlayerEnterAreaDetector palyerDetector;
        [SerializeField]
        private AIMeleeAttackDetector meleeRangeDetector;
        [SerializeField]
        private AIEndPlatformDetector endPlatformDetector;

        [SerializeField]
        private AIBehaviour idleBehavior, chargeBehavior, meleeAttackBehavior, waitBehavior;

        private void Update() {
            aiBoard.SetBoard(AIDataTypes.PlayerDetected, palyerDetector.PlayerInArea);
            aiBoard.SetBoard(AIDataTypes.InMeleeRange, meleeRangeDetector.PlayerDetected);
            aiBoard.SetBoard(AIDataTypes.PathBlocked, endPlatformDetector.PathBlocked);

            if(aiBoard.CheckBoard(AIDataTypes.PlayerDetected)) {

                if(aiBoard.CheckBoard(AIDataTypes.Waiting)) {
                    waitBehavior.PerformAction(this);
                } else {

                    if (aiBoard.CheckBoard(AIDataTypes.InMeleeRange)) {
                        meleeAttackBehavior.PerformAction(this);
                    } else {
                        chargeBehavior.PerformAction(this);
                    }
                }

            } else {
                idleBehavior.PerformAction(this);
            }
        }

    }
}