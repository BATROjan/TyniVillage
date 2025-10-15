using DefaultNamespace.Health;
using UnityEngine;

namespace Player
{
    public class AttackHitBox : MonoBehaviour
    {
        private float timer;
        private int damage;

        public void SetDamage(int value)
        {
            damage = value;
        }
        private void FixedUpdate()
        {
            timer += Time.deltaTime;
            if (timer > 0.1)
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var health = other.GetComponent<HealthController>();
            if (health)
            {
               health.TakeDamage(damage);
            }
        }
    }
}