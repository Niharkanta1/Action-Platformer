using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 00:04:09
================================================================*/

namespace WeaponSystem {
    
    public abstract class WeaponData : ScriptableObject, IEquatable<WeaponData> {
        public string weaponName;
        public Sprite weaponSprite;
        public int weaponDamage = 1;
        public AudioClip weaponSwingSound;

        public abstract bool CanBeUsed(bool isGrounded);
        public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

        public bool Equals(WeaponData other) {
            if (other == null) return false;
            return weaponName == other.weaponName;
        }

        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction) { }
    }
}
