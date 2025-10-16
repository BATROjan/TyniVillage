using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class AttackController: MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected AttackHitBox hitBox;
        [SerializeField] protected Transform[] points;
        [SerializeField] protected int damage;

        private Transform _currentPoint;
        
        protected void BaseAttack()
        {
            var box = Instantiate(hitBox.gameObject).GetComponent<AttackHitBox>();
            box.transform.SetParent(_currentPoint, false);
            box.SetDamage(damage);
        }
        public void ChangePoint(int id)
        {
            _currentPoint = points[id];
        }
    }
}