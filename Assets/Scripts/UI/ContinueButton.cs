using System;
using System.Collections;
using System.Collections.Generic;
using DWG.Levels;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       26-02-2022 13:46:08
================================================================*/
namespace DWG.UI {

    public class ContinueButton : MonoBehaviour {
        public LevelManagement levelManagement;
        public Button continueButton;
        private int _levelIndex = -1;
        public UnityEvent onLevelLoaded;

        private void Awake() {
            if (levelManagement == null) {
                levelManagement = FindObjectOfType<LevelManagement>();
            }

            continueButton = GetComponent<Button>();
        }

        private void Start() {
            _levelIndex = SaveSystem.LoadLevelIndex();
            if (_levelIndex <= -1) return;
            continueButton.onClick.AddListener(() => levelManagement.LoadSceneWithIndex(_levelIndex));
            continueButton.interactable = true;
            onLevelLoaded?.Invoke();
        }
    }
}
