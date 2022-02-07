using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    private float  _playerSpeed = 5f;
    private Vector3 _velocity;
    private float gravityValue = -9.81f;
    private float jumpHeight = 2f;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _controller.isGrounded;
        
        _controller.Move(transform.forward * Input.GetAxis("Vertical") * _playerSpeed * Time.deltaTime);
        _controller.Move(transform.right * Input.GetAxis("Horizontal") * _playerSpeed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravityValue);
        }
        else
        {
            _velocity.y += gravityValue * Time.deltaTime;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }
}
