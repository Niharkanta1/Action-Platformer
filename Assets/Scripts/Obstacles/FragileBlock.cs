using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 19:17:47
================================================================*/

public class FragileBlock : MonoBehaviour, IHittable {

    public UnityEvent onHit;
    
    public void GetHit(GameObject agentGameObject, int weaponDamage) {
        onHit?.Invoke();
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }
}
