using System;
using Player;
using UnityEngine;

namespace DefaultNamespace.Bridge
{
    public class PayZone: MonoBehaviour
    {
        public Action<int> OnPayed;
        private string messenge = "Построй мост из дерева. Постарайся потратить больше дерева чем твой соперник";

        private int _woodCount;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerController>();

            if (player)
            {
                var view = player.GetPayView();
                view.gameObject.SetActive(true);
                view.PrepairCell(messenge);
                var cell = view.GetUICell();
                    cell.OnSetToPepaire += SetWoodCount;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerController>();

            if (player)
            {
                var view = player.GetPayView();
                
                var cell = view.GetUICell();
                cell.OnSetToPepaire -= SetWoodCount;
                
                view.gameObject.SetActive(false);
                view.PrepairCell(null);
            }
        }

        private void SetWoodCount(int value)
        {
            _woodCount = value;
            OnPayed?.Invoke(_woodCount);
        }
    }
}