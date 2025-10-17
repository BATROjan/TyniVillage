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

        private int _maxCount = 100;
        private int _currentCount;
        private int _blueCount;
        private int _redCount;
        private void Start()
        {
            foreach (var zone in payZones)
            {
                zone.OnPayed += Minus;
            }
        }

        public void Minus(int value, PlayerTeam team)
        {
            if (team == PlayerTeam.Blue)
            {
                _blueCount += value;
            }
            else
            {
                _redCount+= value;
            }
            textMeshPro.text = $"{_blueCount} / {_redCount}";
        }
    }
}