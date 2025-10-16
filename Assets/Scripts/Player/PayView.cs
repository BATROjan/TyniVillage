using DefaultNamespace.Items;
using DefaultNamespace.UI;
using UnityEngine;

namespace Player
{
    public class PayView: MonoBehaviour
    {
        [SerializeField] private HintView hintView;
        [SerializeField] private ItemUIView uiView;
        
        public void PrepairCell(string messenge)
        {
            if (messenge != null)
            {
                hintView.gameObject.SetActive(true);
                hintView.Text.text = messenge;
            }
            else
            {
                hintView.gameObject.SetActive(false);
                hintView.Text.text = "";
            }
        }

        public ItemUIView GetUICell()
        {
            return uiView;
        }
    }
}