using System;
using Assets.Scripts.Helpers;
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
            // Forward
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                _playerAnimator.SetBool("IsMovingForward", true);
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                _playerAnimator.SetBool("IsMovingForward", false);

            // Backward
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                _playerAnimator.SetBool("IsMovingBackward", true);
            else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                _playerAnimator.SetBool("IsMovingBackward", false);

            // Left
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                _playerAnimator.SetBool("IsMovingLeft", true);
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                _playerAnimator.SetBool("IsMovingLeft", false);
            // Right
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                _playerAnimator.SetBool("IsMovingRight", true);
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                _playerAnimator.SetBool("IsMovingRight", false);
        }

        private void LoadJumpAnimation()
        {
            if (Input.GetKeyDown(KeyCode.Space) && PlayerController.IsGrounded)
                _playerAnimator.SetTrigger("Jumped");
        }

        public static event Action OnElevationCutsceneTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(TagsHelper.CutsceneTrigger))
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