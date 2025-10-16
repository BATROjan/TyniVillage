using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private Animator animator;

        [SerializeField] private TextMeshProUGUI _HPText;

        private void Start()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            if (_HPText)
            {
                _HPText.text = health.ToString();
                
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            animator.SetBool("TakeDamage", true);
            UpdateText();
            
            if (health <= 0)
            {
                animator.SetBool("Death", true);
            }
        }
    }
}