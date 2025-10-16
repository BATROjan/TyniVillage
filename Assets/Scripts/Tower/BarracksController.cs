using System;
using DefaultNamespace.Creep;
using DefaultNamespace.Player;
using UnityEngine;

namespace DefaultNamespace.Tower
{
    public class BarracksController: MonoBehaviour
    {
        [SerializeField] private Transform[] waysPoint;
        [SerializeField] private float timer;
        [SerializeField] private CreepView creep;
        
        private PlayerBackPackController _backPackController = new PlayerBackPackController();
        private string _towerText = "Спавним скелетиков";
        
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                timer = 0;
                var creepView = Instantiate(creep.gameObject, waysPoint[0]).GetComponent<CreepView>();
                creepView.SetWaysPoints(waysPoint);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _backPackController = other.GetComponent<PlayerBackPackController>();
            if (_backPackController)
            {
                _backPackController.OpenTowerShop(false, null, _towerText);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _backPackController = other.GetComponent<PlayerBackPackController>();
            if (_backPackController)
            {
                _backPackController.OpenTowerShop(false, null, null);
            }
        }
    }
}