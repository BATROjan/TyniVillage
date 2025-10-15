using UnityEngine;

namespace DefaultNamespace.Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private Animator animator;

        public void TakeDamage(int damage)
        {
            health -= damage;
            animator.SetBool("TakeDamage", true);
            if (health <= 0)
            {
                animator.SetBool("Death", true);
            }
        }
    }
}