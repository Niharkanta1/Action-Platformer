using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       01-02-2022 23:39:36
================================================================*/

public class WeaponPickable : Pickable {
    
    [SerializeField]
    private WeaponData weaponData;

    private void Start() {
        spriteRenderer.sprite = weaponData.weaponSprite;
    }

    public override void PickUp(Agent agent) {
        agent.PickUp(weaponData);
    }
}
