using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       01-02-2022 22:47:28
================================================================*/
namespace WeaponSystem {
    [CreateAssetMenu(fileName = "Melee Weapon Data", menuName = "Weapons/RangeWeaponData")]
    public class RangeWeaponData : WeaponData {

        public GameObject rangeWeaponPrefab;
        public float weaponThrowSpeed = 1;  
        public double attackRange = 2;

        public override bool CanBeUsed(bool isGrounded) {
            return true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction) {
            agent.agentWeapon.ToggleWeaponVisibility(false);
            GameObject throwable = Instantiate(rangeWeaponPrefab, agent.agentWeapon.transform.position,
                Quaternion.identity);
            throwable.GetComponent<ThrowableWeapon>().Initialize(this, direction, hittableMask);
        }
    }
}
