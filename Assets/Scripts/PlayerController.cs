using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private CharacterController _controller;

   private const float MouseSensitivity = 100f;
   private const float PlayerSpeed = 5f;
   private Vector3 _velocity;
   private const float GravityValue = -9.81f;
   private const float JumpHeight = .5f;
   private bool _isGrounded = true;

   private Quaternion _currentRot;
   
   // Start is called before the first frame update
   private void Start()
   {
       _controller = GetComponent<CharacterController>();
   }

   // Update is called once per frame
   private void Update()
   {
       _isGrounded = _controller.isGrounded;
       if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
       {
           _velocity.y = Mathf.Sqrt(JumpHeight * -3f * GravityValue);
       }
       else
       {
           _velocity.y += GravityValue * Time.deltaTime * .5f;
       }

       _controller.Move(
           (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal") + _velocity) * PlayerSpeed * Time.deltaTime);
       
       transform.Rotate(0, Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime, 0);

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

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag(Tags.Item))
       {
           Destroy(other.gameObject);
       }
   }
}

