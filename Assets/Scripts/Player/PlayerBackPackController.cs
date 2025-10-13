using System.Collections.Generic;
using DefaultNamespace.Items;
using DefaultNamespace.Tower;
using DefaultNamespace.UI;
using Photon.Pun;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerBackPackController : MonoBehaviour
    {
        [SerializeField] private BackPackPanelView backPackPanelView;
        [SerializeField] private ItemConfig itemConfig;
        [SerializeField] private TowerShopView towerShopView;
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private ItemUIView[] itemUIViews;
        
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
        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<DropItem>();
            if (item)
            {
                var itemType = item.PickUpItem();
                SetItemToPack(item, itemType);
            }
        }

        public TowerShopView GetTowerShopView()
        {
            return towerShopView;
        }
        public void SetItemToPack(DropItem item,ItemType itemType)
        {
            foreach (var itemUI in itemUIViews)
            {
                if (!itemUI.CheckCell()) 
                {
                    itemUI.SetUpItem(itemConfig.GetModel(itemType), true);
                    Destroy(item.gameObject);
                    break;
                }
                if (itemUI.CheckCellToStack())
                {
                    if (itemUI.CheckCellForFull())
                    {
                        itemUI.SetUpItem(itemConfig.GetModel(itemType), true);
                        Destroy(item.gameObject);
                        break;
                    }
                }
            }
        }

        public ItemUIView GetCell(int i)
        {
            return itemUIViews[i];
        }

        public void OpenTowerShop(bool value, List<ItemModel> list)
        {
            towerShopView.SetList(list);
            towerShopView.gameObject.SetActive(value);
        }
    }
}