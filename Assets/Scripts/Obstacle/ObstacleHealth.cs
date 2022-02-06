using UnityEngine;

namespace Obstacle
{
    public class ObstacleHealth : MonoBehaviour
    {
        public float hitPoints = 10f;
        private bool _isDead;

        public void TakeDamage(int damage)
        {
            if (_isDead) return;

            hitPoints -= damage;
            CheckState();
        }

        private void CheckState()
        {
            if (hitPoints < 0 || !_isDead) SetDead();
        }

        private void SetDead()
        {
            _isDead = true;
            GetComponent<MeshDestroy>().DestroyMesh();
        }
    }
}