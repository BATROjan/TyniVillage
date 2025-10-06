using System;
using DefaultNamespace.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Tower
{
    public class TowerController: MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var backPackController = other.GetComponent<PlayerBackPackController>();
            if (backPackController)
            {
                backPackController.OpenTowerShop(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var backPackController = other.GetComponent<PlayerBackPackController>();
            if (backPackController)
            {
                backPackController.OpenTowerShop(false);
            }
        }
    }
}