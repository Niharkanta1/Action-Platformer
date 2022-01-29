using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 13:58:05
================================================================*/

namespace WeaponSystem {
    
    public interface IHittable {

        public void GetHit(GameObject agentGameObject, int weaponDamage);
    }
}
