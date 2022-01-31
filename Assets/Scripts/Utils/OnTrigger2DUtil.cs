using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 22:48:31
================================================================*/
namespace Utils {
    public class OnTrigger2DUtil : MonoBehaviour {
        public LayerMask collisionMask;
        public UnityEvent onTriggerEnterEvent, onTriggerExitEvent;

        private void OnTriggerEnter2D(Collider2D other) {
            if((1 << other.gameObject.layer & collisionMask) != 0) 
                onTriggerEnterEvent?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other) {
            if((1 << other.gameObject.layer & collisionMask) != 0) 
                onTriggerExitEvent?.Invoke();
        }
    }
}
