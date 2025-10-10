using System;
using DefaultNamespace.UI;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI itemCountText;
        
        private ItemType _itemType;
        private bool isFull;
        private bool canStack;
        private int currentCount = 0;
        private int stackCount;
        public void SetUpItem(ItemModel model, bool value)
        {
            _itemType = model.ItemType;
            image.sprite = model.Sprite;
            var imageColor = image.color;
            imageColor.a = model.Alpha;
            image.color = imageColor;
            
            currentCount += model.ItemCount;
            stackCount = model.StackCount;
            canStack = model.CanStack;
            
            isFull = value;
            
            if (isFirst)
            {
                OnChangeType?.Invoke(model, value);
            }

            if (itemCountText)
            {
                if (currentCount > 1)
                {
                    itemCountText.text = currentCount.ToString();
                }
                else
                {
                    itemCountText.text = "";
                }
            }
        }
        

        public bool CheckCell()
        {
            return isFull;
        }

        public bool CheckCellToStack()
        {
            return canStack;
        }

        public bool CheckCellForFull()
        {
            if (currentCount < stackCount)
            {
                return true;
            } 
            return false;
        }
    }
}