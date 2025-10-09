using System;
using DefaultNamespace.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Enviroment.Tree
{
    public class TreeView: MonoBehaviour
    {
        [SerializeField] private ItemType type;
        [SerializeField] private DropItem dropItem;
        [SerializeField] private GameObject[] deleteOjects;
        [SerializeField] private int hitCount;
        [SerializeField] private float timer;
        
        private float distance = 1.2f;
        private float currentTimer;
        private int currentHitCount;
        private bool isReadyToHit;
        public void AAA()
        {
            SpawnSphereOnEdgeRandomly2D();
//            Instantiate(dropItem.gameObject, Random.insideUnitCircle * distance, Quaternion.identity, transform);
        }

        private void Start()
        {
            currentHitCount = hitCount;
            currentTimer = timer;
            isReadyToHit = true;
        }

        private void Update()
        {
            if (!isReadyToHit)
            {
                currentTimer -= Time.deltaTime;
                if (currentTimer < 0 )
                {
                    foreach (var item in deleteOjects)
                    {
                        item.gameObject.SetActive(true);
                    }
                    currentHitCount = hitCount;
                    currentTimer = timer;
                    isReadyToHit = true;
                }
            }
        }

        private void SpawnSphereOnEdgeRandomly2D()
        {
            if (currentHitCount > 0)
            {
                Debug.Log(currentHitCount);
                Vector3 randomPos = Random.insideUnitCircle * distance;
                randomPos += transform.position;

                var model = Resources.Load<ItemConfig>("ItemConfig").GetModel(type);
                GameObject go = Instantiate(dropItem.gameObject, randomPos, Quaternion.identity);
                go.GetComponent<DropItem>().SetUpItem(model);
                go.transform.position = randomPos;
                currentHitCount--;
                if (currentHitCount <= 0)
                {
                    foreach (var item in deleteOjects)
                    {
                        item.gameObject.SetActive(false);
                    }

                    isReadyToHit = false;
                }
            }
        }
    }
}