using UnityEngine;

namespace Player
{
    public class GameController : MonoBehaviour
    {
        private GameManager.GameManager _gameManager;

        void Start()
        {
            _gameManager = FindObjectOfType<GameManager.GameManager>();
        }

        void Update()
        {
            if (Input.GetButton("Reset Scene")) _gameManager.RestartScene();
        }
    }
}