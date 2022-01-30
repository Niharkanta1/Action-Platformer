using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 13:52:57
================================================================*/

namespace WeaponSystem {

    [CreateAssetMenu(fileName = "Melee Weapon Data", menuName = "Weapons/MeleeWeaponData")]
    public class MeleeWeaponData : WeaponData {
        public float attackRange = 2;
        
        public override bool CanBeUsed(bool isGrounded) {
            return isGrounded == true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction) {
            RaycastHit2D hit = Physics2D.Raycast(agent.agentWeapon.transform.position, direction, attackRange,
                hittableMask);
            if (hit.collider == null) return;
            foreach (var hittable in hit.collider.GetComponents<IHittable>()) {
                hittable.GetHit(agent.gameObject, weaponDamage);
            }
        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction) {
            Gizmos.DrawLine(origin, origin + direction * attackRange);
        }
    }
}
