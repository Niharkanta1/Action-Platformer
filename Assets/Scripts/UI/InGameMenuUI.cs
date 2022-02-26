using System;
using System.Collections;
using System.Collections.Generic;
using DWG.Levels;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       27-02-2022 02:29:43
================================================================*/
namespace DWG.UI {
    
    public class InGameMenuUI : MonoBehaviour {

        private LevelManagement _levelManagement;
        public GameObject menuPanel;

        private void Awake() {
            _levelManagement = FindObjectOfType<LevelManagement>();
            if (_levelManagement == null) {
                Debug.LogError("No Level Manager Found.");
            }
        }

        public void ToggleMenu() {
            menuPanel.SetActive(!menuPanel.activeSelf);
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }

        public void LoadMenu() {
            _levelManagement.LoadMenu();
        }

        public void RestartLevel() {
            _levelManagement.RestartCurrentLevel();
        }

        public void ResetTimeScale() {
            Time.timeScale = 1;
        }
    }
}
