using System;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class AnimationController: MonoBehaviour
    {
        public Action OnDeath;
        
        [SerializeField] private Animator animator;

        public void AxeEnd()
        {
            animator.SetBool("Axe", false);
        } 
        public void TakeDamageEnd()
        {
            animator.SetBool("TakeDamage", false);
        } 
        public void AttackEnd()
        {
            animator.SetBool("Attack", false);
        }
        public void Death()
        {
           OnDeath?.Invoke();
        }
    }
}