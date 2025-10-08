using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerMineController : MonoBehaviour
    {
        [SerializeField] private GameObject hitBox;
        [SerializeField] private Transform[] points;
        private Transform _currentPoint;
        private GameObject _box;
        
        public void Hit()
        {
            var _box = Instantiate(hitBox.gameObject);
            _box.transform.SetParent(_currentPoint, false);
        }

        public void DestoyHit()
        {
            if (_box)
            {
                Destroy(_box.gameObject);
            }
        }

        public void ChangePoint(int id)
        {
            _currentPoint = points[id];
        }
    }
}