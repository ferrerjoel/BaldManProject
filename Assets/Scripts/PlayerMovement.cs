using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController cc;
    public float speed = 5f;

    public float gravity = -9.8f;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movementInput = transform.right * x + transform.forward * z;

        cc.Move(movementInput*speed*Time.deltaTime);
        Debug.Log(isGrounded);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 1.1f;
        } else {
            speed =5f;
        }

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity*Time.deltaTime);

    }

}
