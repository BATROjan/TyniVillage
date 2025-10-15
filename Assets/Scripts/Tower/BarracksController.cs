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

        public bool aaa = false;
        private void Update()
        {
            if (!aaa)
            {
                timer += Time.deltaTime;
                if (timer >= 5)
                {
                    aaa = !aaa;
                    timer = 0;
                    var creepView = Instantiate(creep.gameObject, waysPoint[0]).GetComponent<CreepView>();
                    creepView.SetWaysPoints(waysPoint);
                }
            }
           
        }
    }
}