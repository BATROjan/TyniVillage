using System;
using UnityEngine;

namespace DefaultNamespace.Creep
{
    public class CreepDetection: MonoBehaviour
    {
        public Action<Transform> OnPlayerDetected;
        public Action<Transform> OnPlayerLoosed;
        
        private PlayerController _player;
        

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_player)
            {
                _player = other.GetComponent<PlayerController>();
            }
            else
            {
                OnPlayerDetected?.Invoke(_player.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _player = null;
            OnPlayerLoosed?.Invoke(null);
        }
    }
}