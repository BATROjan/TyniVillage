using System;
using DefaultNamespace.Tower;
using DefaultNamespace.UI;
using Photon.Pun;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerBackPackController : MonoBehaviour
    {
        [SerializeField] private BackPackPanelView backPackPanelView;
        [SerializeField] private TowerShopView towerShopView;
        [SerializeField] private PhotonView _photonView;
        private bool _backPackIsOpen;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_photonView.IsMine)
                {
                    _backPackIsOpen = !_backPackIsOpen;
                    backPackPanelView.SetActicePanel(_backPackIsOpen);
                    Debug.Log(_backPackIsOpen);
                }
            }
        }

        public void OpenTowerShop(bool value)
        {
            towerShopView.gameObject.SetActive(value);
        }
    }
}