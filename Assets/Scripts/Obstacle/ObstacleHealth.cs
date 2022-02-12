using UnityEngine;

namespace Obstacle
{
    public class ObstacleHealth : MonoBehaviour
    {
        public float maxHp = 10f;
        public float setDeadDelay = 0.25f;
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
            if (_hitPoints <= 0 && !_isDead) Invoke(nameof(SetDead), 0.25f);
        }

        private void SetDead()
        {
            _isDead = true;
            _hitPoints = 0;
            GetComponent<MeshDestroy>().DestroyMesh(_takenForce);
        }

        public float GetHitPoints()
        {
            return _hitPoints;
        }
    }
}