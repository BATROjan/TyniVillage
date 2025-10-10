using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace.Items
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private ItemModel[] itemModels;

        public ItemModel GetModel(ItemType type)
        {
            ItemModel model = new ItemModel();
            foreach (var itemModel in itemModels)
            {
                if (itemModel.ItemType == type)
                {
                    model = itemModel;
                    break;
                }
            }

            return model;
        }
    }
    
    [Serializable]
    public struct ItemModel
    {
        public ItemType ItemType;
        public Sprite Sprite;
        public bool CanStack;
        public int StackCount;
        public int ItemCount;
        public int Alpha;
    }

    public enum ItemType
    {
        None,
        Axe,
        Wood
    }
}