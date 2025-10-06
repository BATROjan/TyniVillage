using System;
using Photon.Pun;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController: MonoBehaviour
    {
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
        
        private void Start()
        {
            /*Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;*/
            if (!_photonView.IsMine)
            {
                Destroy(GetComponentInChildren<Camera>().gameObject);
                Destroy(rigidbody2D);
            }
        }

        private void FixedUpdate()
        {
            if (_photonView.IsMine)
            {
                PLayerMovement();
            }
            if (rigidbody2D.linearVelocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }

        private void Update()
        {
            if (!_photonView.IsMine)
            {
                return;
            }

            /*RotationCameraVertical();
                RotationPlayerHorizontal();
                if (Input.GetButtonDown("Jump"))
                {
                    TryJump();
                }*/
            
        }

        private void TryJump()
        {
            bool canJump = true;

            Collider[] colliders = Physics.OverlapSphere(transform.position - Vector3.down * 0.5f, checkJumpRadius);
            foreach (var collider in colliders)
            {
                if (collider.gameObject != gameObject)
                {
                    return;
                }
               // rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        private void PLayerMovement()
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            rigidbody2D.linearVelocity = new Vector2(hor, ver) * 5;
            animator.SetFloat("Velocity", rigidbody2D.linearVelocity.magnitude);

            /*Vector3 movement = transform.forward * ver + transform.right * hor;
            movement = Vector3.ClampMagnitude(movement, 1f);
            rigidbody.velocity =
                new Vector3(
                    movement.x * movementSpeed,
                    rigidbody.velocity.y,
                    movement.z * movementSpeed);*/
        }

        private void RotationPlayerHorizontal()
        {
            transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * cameraSensitivity);
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