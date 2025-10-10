using DefaultNamespace.Items;
using DefaultNamespace.Player;
using UnityEngine;

namespace DefaultNamespace
{
    public class DropItem : MonoBehaviour
    {
        [SerializeField] internal SpriteRenderer spriteRenderer;
        internal ItemType _itemType;
        internal int _count;
        internal bool canStack;
        internal void SetUpItem(ItemModel model)
        {
            _itemType = model.ItemType;
            spriteRenderer.sprite = model.Sprite;
            var imageColor = spriteRenderer.color;
            imageColor.a = model.Alpha;

            canStack = model.CanStack;
            _count = model.ItemCount;
        }
        
        public ItemType PickUpItem()
        {
            return _itemType;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            /*var backPackController = other.GetComponent<PlayerBackPackController>();
            if (backPackController)
            {
                backPackController.SetItemToPack(this, _itemType);
            }*/
        }
    }
}