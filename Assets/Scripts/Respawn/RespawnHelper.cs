using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnSystem {

    public class RespawnHelper : MonoBehaviour {
        private RespawnPointManager _manager;

        private void Awake() {
            _manager = FindObjectOfType<RespawnPointManager>();
        }

        public void RespawnPlayer() {
            if (_manager == null) return;
            _manager.Respawn(gameObject);
        }

        public void ResetPlayer() {
            if (_manager == null) return;
            _manager.ResetAllSpawnPoints();
            _manager.Respawn(gameObject);
        }
    }
}
