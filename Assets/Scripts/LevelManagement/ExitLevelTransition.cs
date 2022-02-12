using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       13-02-2022 01:27:55
================================================================*/
namespace DWG.Levels {
    public class ExitLevelTransition : MonoBehaviour {
        [SerializeField] private string playerTag = "Player";
        [SerializeField] private string inputAxisName = "Vertical";
        [SerializeField] private int inputAxisValue = 1;

        private bool _playerInRange;
        public UnityEvent onPlayerEnter, onPlayerExit, onTransition;

        private void Update() {
            if (!_playerInRange) return;
            if ((int) Input.GetAxisRaw(inputAxisName) >= inputAxisValue) {
                onTransition?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag(playerTag)) return;
            _playerInRange = true;
            onPlayerEnter?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (!other.CompareTag(playerTag)) return;
            _playerInRange = false;
            onPlayerExit?.Invoke();
        }
    }
}
