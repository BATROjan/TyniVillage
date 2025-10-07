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
            var item = other.GetComponent<ItemView>();
            if (item)
            {
                var itemType = item.PickUpItem();
                foreach (var itemUI in itemUIViews)
                {
                    if (!itemUI.CheckCell())
                    {
                        itemUI.SetUpItem(Resources.Load<ItemConfig>("ItemConfig").GetModel(itemType), true);
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

        public void OpenTowerShop(bool value)
        {
            towerShopView.gameObject.SetActive(value);
        }
    }
}