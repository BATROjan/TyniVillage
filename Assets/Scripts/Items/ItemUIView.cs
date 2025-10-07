using System;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Items
{
    public class ItemUIView : MonoBehaviour
    {
        public Action<ItemModel, bool> OnChangeType;
        
        [SerializeField] private Image image;
        [SerializeField] private bool isFirst;
        [SerializeField] private UIStatusBarController statusBarController;
        
        private ItemType _itemType;
        private bool isFull;
        
        public void SetUpItem(ItemModel model, bool value)
        {
            _itemType = model.ItemType;
            image.sprite = model.Sprite;
            var imageColor = image.color;
            imageColor.a = model.Alpha;
            image.color = imageColor;
            isFull = value;
            
            if (isFirst)
            {
                OnChangeType?.Invoke(model, value);
            }
        }

        public bool CheckCell()
        {
            return isFull;
        }
        
    }
}