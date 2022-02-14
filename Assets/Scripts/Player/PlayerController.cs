using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

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
        private const float MovementBound = 14.5f;

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

                KeepPlayerInMapBound();
                AlignPlayerToSurface();
            }
        }

        private bool IsPlayerInMovementBound(out char axisOutOfScope)
        {
            bool isInXScope = true;
            bool isInZScope = true;
            axisOutOfScope = ' ';

            if (!(transform.position.x < MovementBound && transform.position.x > -MovementBound))
            {
                axisOutOfScope = 'x';
                isInXScope = false;
            }

            if (!(transform.position.z < MovementBound && transform.position.z > -MovementBound))
            {
                axisOutOfScope = 'z';
                isInZScope = false;
            }

            return (isInXScope && isInZScope);
        }

        private void KeepPlayerInMapBound()
        {
            if (!IsPlayerInMovementBound(out char axisOutOfScope))
            {
                Vector3 newPosition = transform.position;
                switch (axisOutOfScope)
                {
                    case 'x':
                    {
                        if (transform.position.x > MovementBound)
                        {
                            newPosition.x = MovementBound;
                        }
                        else if (transform.position.x < -MovementBound)
                        {
                            newPosition.x = -MovementBound;
                        }

                        break;
                    }

                    case 'z':
                    {
                        if (transform.position.z > MovementBound)
                        {
                            newPosition.z = MovementBound;
                        }
                        else if (transform.position.z < -MovementBound)
                        {
                            newPosition.z = -MovementBound;
                        }

                        break;
                    }
                }

                transform.position = newPosition;
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