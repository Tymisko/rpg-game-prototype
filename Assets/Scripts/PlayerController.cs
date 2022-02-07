using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    private float _mouseSensitivity = 100f;
    private float  _playerSpeed = 5f;
    private Vector3 _velocity;
    private float gravityValue = -9.81f;
    private float jumpHeight = .25f;
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
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravityValue);
        }
        else
        {
            _velocity.y += gravityValue * Time.deltaTime;
        }
        
        _controller.Move((transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal") + _velocity) * _playerSpeed * Time.deltaTime);
        
        transform.Rotate(0, Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime, 0);
    }
}
