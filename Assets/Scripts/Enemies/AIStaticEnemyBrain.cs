using System;
using System.Collections;
using System.Collections.Generic;
using DWG.AI;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       05-02-2022 17:29:01
================================================================*/

public class AIStaticEnemyBrain : AIEnemy {
    public AIBehaviour attackBehaviour;

    private void Update() {
       attackBehaviour.PerformAction(this);
    }
}
