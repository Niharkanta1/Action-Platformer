using System.Collections;
using System.Collections.Generic;
using DWG.AI;
using UnityEngine;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 19:43:57
================================================================*/
namespace DWG.AI {
    public abstract class AIBehaviour : MonoBehaviour {

        public abstract void PerformAction(AIEnemy enemyAI);
    }
}

