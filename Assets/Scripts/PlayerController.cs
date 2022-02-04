using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
  

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));                
    }

    private float speed = 10.0f;
    private void movePlayer(float horizontalInput, float verticalInput)
    {
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        ConstraintPlayerMovements();
    }

    private static float xBoundary = 14.5f;
    private static float yBoundary = 7f;
    private static float zBoundary = 14.5f;

    private void ConstraintPlayerMovements()
    {
        if (transform.position.x > xBoundary || transform.position.x < -xBoundary)
            transform.position = GetLimitedPosition('x');

        if (transform.position.z > zBoundary || transform.position.z < -zBoundary)
            transform.position = GetLimitedPosition('z');

        if (transform.position.y > yBoundary)
            transform.position = GetLimitedPosition('y');
    }

    private Vector3 GetLimitedPosition(char axis)
    {
        Vector3 resetPosition;
        switch (axis)
        {
            case 'x':
                resetPosition = new Vector3(xBoundary * (transform.position.x < 0 ? -1 : 1), transform.position.y, transform.position.z);
                break;
            case 'y':
                resetPosition = new Vector3(transform.position.x, yBoundary, transform.position.z);
                break;
            case 'z':
                resetPosition = new Vector3(transform.position.x, transform.position.y , zBoundary * (transform.position.z < 0 ? -1 : 1));
                break;
            default:
                resetPosition = transform.position;
                break;
        }
        return resetPosition;
    }
}
