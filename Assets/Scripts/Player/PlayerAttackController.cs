using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class PlayerAttackController : AttackController
    {
        public void Attack()
        {
            animator.SetBool("Attack", true);
            BaseAttack();
        }
    }
}