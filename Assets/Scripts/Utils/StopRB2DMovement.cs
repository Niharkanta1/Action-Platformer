using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 22:55:28
================================================================*/
namespace Utils {
    public class StopRB2DMovement : MonoBehaviour {
        [SerializeField]
        private Rigidbody2D rb;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
        }

        public void StopMovement() {
            rb.velocity = Vector2.zero;
        }
    }
}
