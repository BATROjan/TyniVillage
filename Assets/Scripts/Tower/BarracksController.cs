using System;
using DefaultNamespace.Creep;
using UnityEngine;

namespace DefaultNamespace.Tower
{
    public class BarracksController: MonoBehaviour
    {
        [SerializeField] private Transform[] waysPoint;
        [SerializeField] private float timer;
        [SerializeField] private CreepView creep;
        
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
    }
}