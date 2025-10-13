using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Items;
using UnityEngine;

namespace DefaultNamespace.Tower
{
    public class TowerShopView : MonoBehaviour
    {
        [SerializeField] private ItemUIView[] listViews;

        public void SetList( List<ItemModel> list )
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    listViews[i].SetUpItem(list[i], true);
                }
            }
            else
            {
                foreach (var item in listViews)
                {
                    item.ClearCell();
                }
            }
        }

        public List<ItemUIView> GetListOfItems()
        {
            return listViews.ToList();
        }
    }
}