using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       26-02-2022 15:25:31
================================================================*/
namespace DWG.Levels {
    
    public interface ISaveData {
        void SaveData();
        void LoadData();
    }
}
