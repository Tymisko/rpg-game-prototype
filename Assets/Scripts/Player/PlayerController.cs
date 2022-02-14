using System;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _controller;

        private const float MouseSensitivity = 100f;
        private const float PlayerSpeed = 5f;
        private const float GravityValue = -9.81f;
        private const float JumpHeight = .125f;

        private const float GravityModifier = .5f;
        private const float JumpDirectionModifier = -3f;

        private Vector3 _jumpDirection;

        public static bool IsGrounded = true;

        public static event Action OnPlayerMoved;
        public static event Action OnPlayerJumped;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (!CameraController.CutsceneTriggered)
            {
                IsGrounded = _controller.isGrounded;
                SetJumpDirection();

                float verticalInput = Input.GetAxis("Vertical");
                float horizontalInput = Input.GetAxis("Horizontal");
                MovePlayer(verticalInput, horizontalInput, _jumpDirection);

                var xAxisMouseInput = Input.GetAxis("Mouse X");
                MoueSteering(xAxisMouseInput);

                AlignPlayerToSurface();
            }
        }

        private Quaternion _currentRot;

        private void AlignPlayerToSurface()
        {
            var ray = new Ray(transform.position, -transform.up);
            if (Physics.Raycast(ray, out RaycastHit hit, 1.5f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
                _currentRot = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            }

            if (IsGrounded)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, _currentRot, Time.deltaTime * 5f);
            }
        }

        private void MoueSteering(float xAxisMouseInput)
        {
            transform.Rotate(0, xAxisMouseInput * MouseSensitivity * Time.deltaTime, 0);
        }

        private void MovePlayer(float verticalInput, float horizontalInput, Vector3 jumpDirection)
        {
            _controller.Move(
                (transform.forward * verticalInput
                 + transform.right * horizontalInput
                 + jumpDirection) * PlayerSpeed * Time.deltaTime);

            if (InputHelper.AnyKewDown(InputHelper.MovementKeys) && IsGrounded)
                OnPlayerMoved?.Invoke();

            if (Input.GetKey(KeyCode.Space) && IsGrounded)
                OnPlayerJumped?.Invoke();
        }

        private void SetJumpDirection()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                _jumpDirection.y = Mathf.Sqrt(JumpHeight * JumpDirectionModifier * GravityValue);
            }
            else
            {
                _jumpDirection.y += GravityValue * Time.deltaTime * GravityModifier;
            }
        }
    }
}