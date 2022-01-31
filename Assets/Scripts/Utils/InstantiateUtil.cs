using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 23:19:46
================================================================*/
namespace Utils {

    public class InstantiateUtil : MonoBehaviour {

        [SerializeField] private GameObject objectToInstantiate;

        public void CreateObject() {
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
    }
}
