using System;
using DefaultNamespace.Enviroment.Tree;
using UnityEngine;

namespace Player
{
    public class HitBoxView : MonoBehaviour
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
            if (other.GetComponent<TreeView>())
            {
                other.GetComponent<TreeView>().AAA();
            }
        }
    }
}