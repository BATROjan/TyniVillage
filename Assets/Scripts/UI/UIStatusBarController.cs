using System;
using DefaultNamespace.Items;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class UIStatusBarController : MonoBehaviour
    {
        public Action<ItemType> OnChangeItem;
        
        [SerializeField] private ItemUIView itemUIView;
        
        public void SetUpItem(ItemModel model, bool value)
        {
            itemUIView.SetUpItem(model, value); 
            OnChangeItem?.Invoke(model.ItemType);
        }
    }
}