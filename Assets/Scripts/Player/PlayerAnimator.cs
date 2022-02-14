using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private GameObject _playerBody;
        private Animator _playerAnimator;

        void Awake()
        {
            _playerAnimator = _playerBody.GetComponent<Animator>();
        }

        void Update()
        {
            if (!CameraController.CutsceneTriggered)
            {
                LoadMovementAnimations();
                LoadJumpAnimation();
            }
            else
            {
                ResetMovementAnimations();
            }
        }

        private void LoadMovementAnimations()
        {
            _playerAnimator.SetBool("IsMovingForward", Input.GetKey(KeyCode.W));
            _playerAnimator.SetBool("IsMovingBackward", Input.GetKey(KeyCode.S));
            _playerAnimator.SetBool("IsMovingLeft", Input.GetKey(KeyCode.A));
            _playerAnimator.SetBool("IsMovingRight", Input.GetKey(KeyCode.D));
        }

        private void LoadJumpAnimation()
        {
            if (Input.GetKey(KeyCode.Space) && PlayerController.IsGrounded)
                _playerAnimator.SetTrigger("Jumped");
        }

        public static event Action OnElevationCutsceneTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.CutsceneTrigger))
            {
                OnElevationCutsceneTriggered?.Invoke();
            }
        }

        private void ResetMovementAnimations()
        {
            _playerAnimator.SetBool("IsMovingForward", false);
            _playerAnimator.SetBool("IsMovingBackward", false);
            _playerAnimator.SetBool("IsMovingLeft", false);
            _playerAnimator.SetBool("IsMovingRight", false);
        }
    }
}