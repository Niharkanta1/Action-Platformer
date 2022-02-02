using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       02-02-2022 17:04:38
================================================================*/

public class PointPickable : Pickable {

    public UnityEvent onPickUp;
    [SerializeField] private int pointsToAdd = 1;
    
    public override void PickUp(Agent agent) {
        PlayerPoints playerPoints = agent.GetComponent<PlayerPoints>();
        playerPoints.Add(pointsToAdd);
    }
}
