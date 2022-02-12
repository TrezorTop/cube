using UnityEngine;

namespace GameManager
{
    public class FinishTrigger : MonoBehaviour
    {
        private GameManager _gameManager;


        private float _elapsedTime;
        public float stayTimeToFinish = 3f;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            if (!collisionInfo.gameObject.CompareTag("Player")) return;

            collisionInfo.rigidbody.sleepThreshold = 0;

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= stayTimeToFinish) RestartScene();
        }

        private void OnCollisionExit()
        {
            _elapsedTime = 0f;
        }

        private void RestartScene()
        {
            _gameManager.RestartScene();
        }
    }
}