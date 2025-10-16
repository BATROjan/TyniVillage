using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace DefaultNamespace.Bridge
{
    public class BridgeController : MonoBehaviour
    {
        [SerializeField] private PayZone[] payZones;
        [SerializeField] private GameObject[] cells;
        [SerializeField] private TextMeshProUGUI textMeshPro;

        private int count = 100;

        private void Start()
        {
            foreach (var zone in payZones)
            {
                zone.OnPayed += Minus;
            }
        }

        public void Minus(int value)
        {
            textMeshPro.text = (count - value).ToString();
        }
    }
}