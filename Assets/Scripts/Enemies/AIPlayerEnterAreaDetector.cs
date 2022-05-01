using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-04-2022 19:35:18
================================================*/
namespace DWG.AI {
    public class AIPlayerEnterAreaDetector : MonoBehaviour {

        [field: SerializeField]
        public bool PlayerInArea { get; private set; }
        public Transform Player { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.CompareTag("Player")) {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if(collision.CompareTag("Player")) {
                PlayerInArea = false;
                Player = null;
            }
        }
    }
}