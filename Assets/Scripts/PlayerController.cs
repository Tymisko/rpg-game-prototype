using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private CharacterController _controller;
   private const float MouseSensitivity = 100f;
   
   private const float PlayerSpeed = 5f;
   
   private const float GravityValue = -9.81f;
   private const float JumpHeight = .5f;
   private bool _isGrounded = true;

   private Quaternion _currentRot;
   
   private void Start()
   {
       _controller = GetComponent<CharacterController>();
   }

   private void Update()
   {
       Vector3 jumpDirection = GetJumpDirection();
       float verticalInput = Input.GetAxis("Vertical");
       float horizontalInput = Input.GetAxis("Horizontal");
       MovePlayer(verticalInput, horizontalInput, jumpDirection);

       var xAxisMouseInput = Input.GetAxis("Mouse X");
       MoueSteering(xAxisMouseInput);

       AlignPlayerToSurface();
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
       transform.Rotate(0,  xAxisMouseInput * MouseSensitivity * Time.deltaTime, 0);
   }

   private void MovePlayer(float verticalInput, float horizontalInput, Vector3 jumpDirection)
   {
       _controller.Move((transform.forward * verticalInput + transform.right * horizontalInput + jumpDirection) * PlayerSpeed * Time.deltaTime);
   }

   private Vector3 GetJumpDirection()
   {
       Vector3 velocity = new Vector3();

       _isGrounded = _controller.isGrounded;
       
       if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
       {
           velocity.y = Mathf.Sqrt(JumpHeight * -3f * GravityValue);
       }
       else
       {
           velocity.y += GravityValue * Time.deltaTime * .5f;
       }

       return velocity;
   }
}

