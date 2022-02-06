using Obstacle;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag("Obstacle")) return;
            
            var target = collision.gameObject.GetComponent<ObstacleHealth>();
            target.TakeDamage(15);
        }
    }
}