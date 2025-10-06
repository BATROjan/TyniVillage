using UnityEngine;

namespace DefaultNamespace
{
    public class Menu : MonoBehaviour
    {
        public string MenuName;

        public void Open()
        {
            gameObject.SetActive(true);
        }
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}