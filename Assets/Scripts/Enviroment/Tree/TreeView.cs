using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Enviroment.Tree
{
    public class TreeView: MonoBehaviour
    {
        [SerializeField] private DropItem dropItem;
        [SerializeField] private GameObject[] deleteOjects;
        [SerializeField] private int hitCount;
        
        public float distance = 1.2f;
        public void AAA()
        {
            SpawnSphereOnEdgeRandomly2D();
//            Instantiate(dropItem.gameObject, Random.insideUnitCircle * distance, Quaternion.identity, transform);
        }

        private void SpawnSphereOnEdgeRandomly2D()
        {
            if (hitCount > 0)
            {
                Vector3 randomPos = Random.insideUnitCircle * distance;
                randomPos += transform.position;
            
                GameObject go = Instantiate(dropItem.gameObject, randomPos, Quaternion.identity);
                go.transform.position = randomPos;
                hitCount--;
            }
            else
            {
                foreach (var item in deleteOjects)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}