using System;
using System.Collections.Generic;
using DefaultNamespace.Items;
using DefaultNamespace.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Tower
{
    public class TowerController: MonoBehaviour
    {
        [SerializeField] private ItemView itemView;
        [SerializeField] private ItemConfig itemConfig;
        [SerializeField] private int maxItemCount;
        

        private float axeTimer;
        private List<ItemModel> _listItem = new List<ItemModel>();
        private List<ItemUIView> _listTypes = new List<ItemUIView>();
        private bool hasPlayer;
        private PlayerBackPackController _backPackController = new PlayerBackPackController();
        private void OnTriggerEnter2D(Collider2D other)
        {
            _backPackController = other.GetComponent<PlayerBackPackController>();
            if (_backPackController)
            {
                hasPlayer = true;
                _backPackController.OpenTowerShop(true, _listItem);
                var shop = _backPackController.GetTowerShopView();
                _listTypes = shop.GetListOfItems();
                foreach (var item in _listTypes)
                {
                    item.OnGetFromShop += RemoveItemFromList;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_backPackController)
            {
                hasPlayer = false;
                _backPackController.OpenTowerShop(false, null);
            }
            foreach (var item in _listTypes)
            {
                item.OnGetFromShop -= RemoveItemFromList;
            }
            _listTypes.Clear();
        }

        private void RemoveItemFromList(ItemType type)
        {
            _listItem.Remove(itemConfig.GetModel(type));
        }

        public void Update()
        {
            if (_listItem.Count < maxItemCount)
            {
                axeTimer += Time.deltaTime;
                if (axeTimer >= 10)
                {
                    axeTimer = 0;
                    _listItem.Add(itemConfig.GetModel(ItemType.Axe));
                    if (hasPlayer)
                    {
                        _backPackController.OpenTowerShop(true, _listItem);
                    }
                }
            }
        }
    }
}