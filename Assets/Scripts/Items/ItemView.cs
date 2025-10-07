using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Items
{
    public class ItemView: MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private ItemType _itemType;
        
        public void SetUpItem(ItemModel model)
        {
            _itemType = model.ItemType;
            spriteRenderer.sprite = model.Sprite;
            var imageColor = spriteRenderer.color;
            imageColor.a = model.Alpha;
        }

        public ItemType PickUpItem()
        {
            return _itemType;
        }
    }
}