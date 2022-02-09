using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Body;
    private Animator _animator;
    private CharacterController _controller;
    private const float MouseSensitivity = 100f;

    private const float PlayerSpeed = 5f;
    private Vector3 _velocity;

    private const float GravityValue = -9.81f;
    private const float JumpHeight = .5f;
    private bool _isGrounded = true;

    private Quaternion _currentRot;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = Body.GetComponent<Animator>();
    }

    private void Update()
    {
        GetJumpDirection();

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        MovePlayer(verticalInput, horizontalInput, _velocity);

        var xAxisMouseInput = Input.GetAxis("Mouse X");
        MoueSteering(xAxisMouseInput);

        // AlignPlayerToSurface();
    }

    private void AlignPlayerToSurface()
    {
        var ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit, 1.5f))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            _currentRot = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (_isGrounded)
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
        if(Input.GetKey(KeyCode.W))
            _animator.SetBool("IsMovingForward", true);
        else
            _animator.SetBool("IsMovingForward", false);
        
        if(Input.GetKey(KeyCode.S))
            _animator.SetBool("IsMovingBackward", true);
        else
            _animator.SetBool("IsMovingBackward", false);
        
        if(Input.GetKey(KeyCode.A))
            _animator.SetBool("IsMovingLeft", true);
        else
            _animator.SetBool("IsMovingLeft", false);
        
        if(Input.GetKey(KeyCode.D))
            _animator.SetBool("IsMovingRight", true);
        else
            _animator.SetBool("IsMovingRight", false);
        
        // if(Input.GetKey(KeyCode.Space))
        //     _animator.SetBool("Jump", true);
        // else if(_isGrounded)
        //     _animator.SetBool("Jump", false);

        // if (Input.GetKey(KeyCode.W))
        // {
        //     _animator.SetBool("MoveForward", true);
        //     _animator.SetBool("IsIdle", false);
        // }
        //     
        // else
        // {
        //     _animator.SetBool("MoveForward", false);
        //     _animator.SetBool("IsIdle", true);
        // }
        _controller.Move((transform.forward * verticalInput + transform.right * horizontalInput + jumpDirection) *
                         PlayerSpeed * Time.deltaTime);
    }

    private void GetJumpDirection()
    {
        _isGrounded = _controller.isGrounded;
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(JumpHeight * -3f * GravityValue);
        }
        else
        {
            _velocity.y += GravityValue * Time.deltaTime * .5f;
        }
    }
}