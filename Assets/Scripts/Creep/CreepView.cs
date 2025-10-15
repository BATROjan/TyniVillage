using System;
using DefaultNamespace.Player;
using UnityEngine;

namespace DefaultNamespace.Creep
{
    public class CreepView: MonoBehaviour
    {
        [SerializeField] private Transform[] waysPoint;
        [SerializeField] private Animator animator;
        [SerializeField] private CreepDetection detection;
        [SerializeField] private AnimationController animationController;
        [SerializeField] private float speed;

        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private PolygonCollider2D collider2D;
            
        
        private int currentpoint = 1;
        private float des;
        private float _delayAfterDeath = 2;
        private Vector3 currentTargetPosition;
        private bool isPoint;
        private bool isDeath;
        
        private void Start()
        {
            animationController.OnDeath += Death;
            isPoint = true;
            des = 0.01f;
            detection.OnPlayerDetected += ChangeTarget;
            detection.OnPlayerLoosed += ChangeTarget;
        }

        private void Death()
        {
            isDeath = true;
        }

        private void ChangeTarget(Transform transform)
        {
            if (transform)
            {
                currentTargetPosition = transform.position;
                isPoint = false;
                des = 0.1f;
            }
            else
            {
                currentTargetPosition = waysPoint[currentpoint].position;
                isPoint = true;
                des = 0.01f;
            }
        }

        private void Update()
        {
            if (!animator.GetBool("TakeDamage") || !animator.GetBool("Death"))
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, currentTargetPosition, speed * Time.deltaTime);
                if (Vector3.SqrMagnitude(transform.position - currentTargetPosition) < des)
                {
                    if (isPoint)
                    {
                        currentpoint++;
                        currentTargetPosition = waysPoint[currentpoint].position;
                    }
                    else
                    {
                        Debug.Log("Attack");
                    }
                } 
            }

            if (isDeath)
            {
                _delayAfterDeath -= Time.deltaTime;
                if (_delayAfterDeath <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        public void SetWaysPoints(Transform[] transforms)
        {
            waysPoint = transforms;
            currentTargetPosition = waysPoint[currentpoint].position;
        }
    }
}