using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 22:39:27
================================================================*/
namespace Utils {

    public class DestroyGO : MonoBehaviour {
        
        public void DestroySelf() {
            Destroy(gameObject);
        }

        public void DestroyObject(GameObject objectToDestroy) {
            Destroy(objectToDestroy);
        }
    }
}
