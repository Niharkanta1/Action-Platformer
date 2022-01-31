using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 22:37:47
================================================================*/

public class HealthPickable : Pickable {
    [SerializeField]
    private int healthBoost = 1;
    
    public override void PickUp(Agent agent) {
        Damageable damageable = agent.GetComponent<Damageable>();
        if (damageable == null) {
            return;
        }
        damageable.AddHealth(healthBoost);
    }
}
