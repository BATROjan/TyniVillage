using UnityEngine;

namespace DefaultNamespace.Creep
{
    public class CreepAttackController : AttackController
    {
        public void Attack()
        {
            animator.SetBool("Attack", true);
        }
    }
}