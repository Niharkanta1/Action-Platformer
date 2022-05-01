using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       01-05-2022 13:40:43
================================================*/

namespace DWG.UI {

    public class BossUI : MonoBehaviour {
        public GameObject healthPanel;
        public Slider slider;

        public void Initialize(int value) {
            slider.maxValue = value;
        }
        
        public void SetHealth(int value) {
            slider.value = value;
        }

        public void ToggleHealthPanel(bool value) {
            healthPanel.SetActive(value);
        }
    }
}