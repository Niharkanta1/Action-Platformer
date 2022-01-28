using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnSystem {
    
    public class RespawnPointManager : MonoBehaviour {
        private List<RespawnPoint> _respawnPoints = new List<RespawnPoint>();
        private RespawnPoint _currentRespawnPoint;

        private void Awake() {
            foreach (Transform item in transform) {
                _respawnPoints.Add(item.GetComponent<RespawnPoint>());
            }

            _currentRespawnPoint = _respawnPoints[0];
        }

        public void UpdateRespawnPoint(RespawnPoint newRespawnPoint) {
            _currentRespawnPoint.DisableRespawnPoint();
            _currentRespawnPoint = newRespawnPoint;
        }

        public void Respawn(GameObject objectToRespawn) {
            _currentRespawnPoint.RespawnObject();
            objectToRespawn.SetActive(true);
        }

        public void RespawnAt(RespawnPoint respawnPoint, GameObject playerGameObject) {
            respawnPoint.SetPlayerGameObject(playerGameObject);
            Respawn(playerGameObject);
        }

        public void ResetAllSpawnPoints() {
            foreach (var item in _respawnPoints) {
                item.ResetRespawnPoint();
            }

            _currentRespawnPoint = _respawnPoints[0];
        }
    }
    
}
