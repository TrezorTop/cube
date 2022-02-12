using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        private bool _sceneHasRestarted;

        private void Awake()
        {
            _sceneHasRestarted = false;
        }

        public void RestartScene()
        {
            if (_sceneHasRestarted) return;

            Debug.Log("RestartScene");
            Restart();
            _sceneHasRestarted = true;
        }

        private static void Restart()
        {
            var currentScene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(currentScene.name);
        }
    }
}