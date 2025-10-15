using DefaultNamespace.Items;
using Player;
using UnityEngine;

namespace DefaultNamespace.Enviroment
{
    public class MineEnviroment : MonoBehaviour
    {
        [SerializeField] protected ItemConfig itemConfig;
        [SerializeField] protected ItemType type;
        [SerializeField] protected DropItem dropItem;
        [SerializeField] protected GameObject[] deleteOjects;
        [SerializeField] protected int hitCount;
        [SerializeField] protected float timer;
        
        private float distance = 1.2f;
        private float currentTimer;
        private int currentHitCount;
        private bool isReadyToHit;
        
        public void SpawnDrop()
        {
            SpawnSphereOnEdgeRandomly2D();
        }

        protected void Start()
        {
            currentHitCount = hitCount;
            currentTimer = timer;
            isReadyToHit = true;
        }

        protected void Update()
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
                Vector3 randomPos = Random.insideUnitCircle * distance;
                randomPos += transform.position;

                var model = itemConfig.GetModel(type);
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