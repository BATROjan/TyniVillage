using System;
using DefaultNamespace.Items;
using DefaultNamespace.Player;
using DefaultNamespace.UI;
using Photon.Pun;
using Player;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController: MonoBehaviour
    {
        [SerializeField] private UIStatusBarController statusBarController;
        [SerializeField] private PlayerBackPackController playerBackPackController;
        [SerializeField] private PlayerMineController playerMineController;
        
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float cameraSensitivity;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float checkJumpRadius;
        [SerializeField] private float jumpForce;

        private float rotationX;
        private ItemType currentItemType;
        private void Start()
        {
            if (!_photonView.IsMine)
            {
                Destroy(GetComponentInChildren<Camera>().gameObject);
                Destroy(rigidbody2D);
              
            }
            playerBackPackController.GetCell(0).OnChangeType += statusBarController.SetUpItem;
            statusBarController.OnChangeItem += ChangeType;
        }

        private void FixedUpdate()
        {
            if (_photonView.IsMine)
            {
                PLayerMovement();
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("Axe");
                    if (currentItemType == ItemType.Axe)
                    {
                        animator.SetBool("Axe", true);
                    }
                }
            }
        }

        private void Update()
        {
            if (!_photonView.IsMine)
            {
                return;
            }
        }
        
        private void PLayerMovement()
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            rigidbody2D.linearVelocity = new Vector2(hor, ver) * 5;
            animator.SetFloat("Velocity", rigidbody2D.linearVelocity.magnitude);
            if (hor < 0)
            {
                spriteRenderer.flipX = true;
                playerMineController.ChangePoint(1);
            }
            if (hor > 0)
            {
                spriteRenderer.flipX = false;
                playerMineController.ChangePoint(0);
            }
        }

        private void RotationPlayerHorizontal()
        {
            transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * cameraSensitivity);
        }

        private void ChangeType(ItemType type)
        {
            currentItemType = type;
        }

        private void RotationCameraVertical()
        {
            rotationX -= cameraSensitivity * Input.GetAxisRaw("Mouse Y");
            rotationX = Math.Clamp(rotationX, -75, 75);
            cameraTransform.eulerAngles =
                new Vector3(rotationX, cameraTransform.eulerAngles.y, cameraTransform.eulerAngles.z);
        }
    }
}