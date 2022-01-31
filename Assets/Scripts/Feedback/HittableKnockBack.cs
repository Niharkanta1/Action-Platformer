using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 15:35:49
================================================================*/

public class HittableKnockBack : MonoBehaviour, IHittable {
    
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float force = 10;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetHit(GameObject opponentAgent, int weaponDamage) {
        Vector2 direction = transform.position - opponentAgent.transform.position;
        rb.AddForce(new Vector2(direction.normalized.x, 0) * force, ForceMode2D.Impulse);
    }   
    
}
