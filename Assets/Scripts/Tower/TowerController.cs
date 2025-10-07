using System;
using DefaultNamespace.Items;
using DefaultNamespace.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Tower
{
    public class TowerController: MonoBehaviour
    {
        [SerializeField] private ItemView itemView;
        private float timer;
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

        public void Update()
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                timer = 0;
                var item = Instantiate(itemView.gameObject).GetComponent<ItemView>();
                item.SetUpItem(Resources.Load<ItemConfig>("ItemConfig").GetModel(ItemType.Axe));
                var collider2D = item.AddComponent<PolygonCollider2D>();
                collider2D.isTrigger = true;
                item.transform.position = new Vector2(-38, 5);
            }
        }
    }
}