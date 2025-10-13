using System;
using DefaultNamespace.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DefaultNamespace.Items
{
    public struct ItemUIModel
    {
        public Sprite Sprite;
        public bool IsFirst;
        public ItemType ItemType;
        public bool IsFull;
        public bool CanStack;
        public int CurrentCount;
        public int StackCount;
        public float alpha;
    }
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
        private float aplha;
        
        public void SetUpItem(ItemModel model, bool value)
        {
            _itemType = model.ItemType;
            image.sprite = model.Sprite;
            var imageColor = image.color;
            imageColor.a = model.Alpha;
            aplha = imageColor.a;
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

        public void ChangeItem(ItemUIModel model)
        {
            _itemType = model.ItemType;
            image.sprite = model.Sprite;
            var imageColor = image.color;
            imageColor.a = model.alpha;
            aplha = imageColor.a;
            image.color = imageColor;
            
            currentCount = model.CurrentCount;
            stackCount = model.StackCount;
            canStack = model.CanStack;
            
            isFull = model.IsFull;
            
            if (isFirst)
            {
                OnChangeType?.Invoke(Resources.Load<ItemConfig>("ItemConfig").GetModel(_itemType), isFull);
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

        public ItemUIModel GetItemModel()
        {
            ItemUIModel model = new ItemUIModel();
            model.alpha = aplha;
            model.ItemType = _itemType;
            model.CanStack = canStack;
            model.IsFull = isFull;
            model.IsFirst = isFirst;
            model.Sprite = image.sprite;
            model.CurrentCount = currentCount;
            model.StackCount = stackCount;
            return model;
        }
        
    }
}