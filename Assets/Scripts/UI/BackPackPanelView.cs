using UnityEngine;

namespace DefaultNamespace.UI
{
    public class BackPackPanelView : MonoBehaviour
    {
        public void SetActicePanel(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}