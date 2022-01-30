using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 14:42:44
================================================================*/
namespace WeaponSystem {

    public class GiveAgentAWeapon : MonoBehaviour {
        public List<WeaponData> weaponData = new List<WeaponData>();

        private void Start() {
            Agent agent = GetComponentInChildren<Agent>();
            if (agent == null) return;
            foreach (var item in weaponData) {
                agent.agentWeapon.AddWeaponData(item);
            }
        }
    }
}
