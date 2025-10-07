using UnityEngine;

namespace DefaultNamespace.Player
{
    public class AnimationController: MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void AxeEnd()
        {
            animator.SetBool("Axe", false);
        }
    }
}