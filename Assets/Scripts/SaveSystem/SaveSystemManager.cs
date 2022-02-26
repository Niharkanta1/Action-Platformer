using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       26-02-2022 12:58:19
================================================================*/

namespace DWG.Levels {
    
    public class SaveSystemManager : MonoBehaviour {
        public void ResetSavedData() {
            SaveSystem.ResetSaveData();
        }
    }
}
