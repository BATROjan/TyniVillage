using System;
using DefaultNamespace.Enviroment;
using DefaultNamespace.Enviroment.Tree;
using UnityEngine;

namespace Player
{
    public class MineHitBoxView : MonoBehaviour
    {
        private float timer;
        private void FixedUpdate()
        {
            timer += Time.deltaTime;
            if (timer > 0.1)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var aaa = other.GetComponent<MineEnviroment>();
            if (aaa)
            {
                aaa.SpawnDrop();
            }
        }
    }
}