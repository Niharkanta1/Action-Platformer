using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RespawnSystem {
    
    public class RespawnPoint : MonoBehaviour {
        
        [SerializeField] private GameObject respawnTarget;
        
        [field: SerializeField]
        private UnityEvent onSpawnPointActivated { get; set; }

        private void Start() {
            onSpawnPointActivated.AddListener((() => GetComponentInParent<RespawnPointManager>().UpdateRespawnPoint(this)));
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (!other.CompareTag("Player")) return;
            respawnTarget = other.gameObject;
            onSpawnPointActivated?.Invoke();
        }

        public void DisableRespawnPoint() {
            GetComponent<Collider2D>().enabled = false;
        }

        public void ResetRespawnPoint() {
            respawnTarget = null;
            GetComponent<Collider2D>().enabled = true;
        }

        public void RespawnObject() {
            respawnTarget.transform.position = transform.position;
        }

        public void SetPlayerGameObject(GameObject playerGameObject) {
            respawnTarget = playerGameObject;
            GetComponent<Collider2D>().enabled = false;
        }
    }
    
}

