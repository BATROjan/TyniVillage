using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager instance;
        
        [SerializeField] private List<Menu> _menus;
        private void Awake()
        {
            instance = this;
        }

        public void OpenMenu(string name)
        {
            foreach (var item in _menus)
            {
                if (item.MenuName == name)
                {
                    item.Open();
                }
                else
                {
                    item.Close();
                }
            } 
        }
    }
}