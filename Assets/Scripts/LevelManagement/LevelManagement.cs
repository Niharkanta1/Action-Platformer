using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       12-02-2022 21:32:18
================================================================*/
namespace DWG.Levels {
    public class LevelManagement : MonoBehaviour {

        [SerializeField] private int level1BuildSceneIndex, menuBuildSceneIndex, winSceneBuildIndex;

        public void RestartCurrentLevel() {
            LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadStartLevel() {
            LoadSceneWithIndex(level1BuildSceneIndex);
        }

        public void LoadNextLevel() {
            LoadSceneWithIndex(GetNextLevelIndex());
        }

        public void LoadMenu() {
            LoadSceneWithIndex(menuBuildSceneIndex);
        }

        public void LoadWinScene() {
            LoadSceneWithIndex(winSceneBuildIndex);
        }

        public int GetNextLevelIndex() {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            return index < SceneManager.sceneCountInBuildSettings ? index : winSceneBuildIndex;
        }

        public void LoadSceneWithIndex(int index) {
            SceneManager.LoadScene(index);
        }

        public void QuitGame() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
