using UnityEngine;

namespace Obstacle
{
    public class ObstacleHealth : MonoBehaviour
    {
        public float maxHp = 10f;
        private float _hitPoints;
        private bool _isDead;
        private float _takenForce;

        private void Start()
        {
            _hitPoints = maxHp;
        }

        public void TakeDamage(float damage)
        {
            if (_isDead) return;

            _takenForce = damage;

            _hitPoints -= damage;
            CheckState();
        }

        private void CheckState()
        {
            if (_hitPoints <= 0 && !_isDead) SetDead();
        }

        private void SetDead()
        {
            _isDead = true;
            GetComponent<MeshDestroy>().DestroyMesh(_takenForce);
        }

        public float GetHitPoints()
        {
            return _hitPoints;
        }
    }
}