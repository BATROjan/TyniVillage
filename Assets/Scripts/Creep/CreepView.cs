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
        [SerializeField] private CreepAttackController attackController;
        [SerializeField] private float speed;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private Collider2D collider2D;
            
        
        private int currentpoint = 1;
        private float _lasPosX;
        private float des;
        private float _delayAfterDeath = 2;
        private Vector3 currentTargetPosition;
        private bool isPoint;
        private bool isDeath;
        
        private void Start()
        {
            animationController.OnDeath += Death;
            isPoint = true;
            des = 0.5f;
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
            }
            else
            {
                if (currentpoint < waysPoint.Length)
                {
                    currentTargetPosition = waysPoint[currentpoint].position;
                }
                
                isPoint = true;
            }
        }

        private void Update()
        {
            if (!animator.GetBool("TakeDamage") 
                || !animator.GetBool("Death")
                || !animator.GetBool("Attack"))
            {
                var dir = _lasPosX - transform.position.x;
                _lasPosX = transform.position.x;
                
                if (dir > 0)
                {
                    spriteRenderer.flipX = true;
                    attackController.ChangePoint(1);
                }
                if (dir < 0)
                {
                    spriteRenderer.flipX = false;
                    attackController.ChangePoint(0);
                }
                
                transform.position = Vector3.MoveTowards(
                    transform.position, currentTargetPosition, speed * Time.deltaTime);
                if (Vector3.SqrMagnitude(transform.position - currentTargetPosition) < des)
                {
                    if (isPoint)
                    {
                        currentpoint++;
                        if (currentpoint < waysPoint.Length)
                        {
                            currentTargetPosition = waysPoint[currentpoint].position;
                        }
                    }
                    else
                    {
                        attackController.Attack();
                    }
                } 
            }

            if (isDeath)
            {
                _delayAfterDeath -= Time.deltaTime;
                if (_delayAfterDeath <= 0)
                {
                    collider2D.enabled = false;
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