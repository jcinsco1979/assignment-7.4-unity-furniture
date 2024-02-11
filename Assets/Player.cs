using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //this moves my camera left right up down
    public float rotationX = 0;
    public float rotationY = 0;

    //decided speed of camera
    public float rotationSpeed;

    public float movementSpeed;
    // Start is called before the first frame update

    public Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculate rotation with respect to mouse input
        rotationX += Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f); //Limit rotation angle


        //assign rotation to the object
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);

        //movement WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //go to project settings and input manager in unity for wasd buttons
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        Vector3 movement = movementDirection.normalized * movementSpeed;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
