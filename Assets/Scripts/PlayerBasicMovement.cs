using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    //Moving variables
    public float movementSpeed;
    public float jumpHeight;
    //Jumping variables
    private bool canMove;
    private bool isGrounded;
    //Compoonent variables
    private Rigidbody rb;
    private Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Start movement function.
        PlayerMovement(movementSpeed);
        //When the player wants to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
            animate.SetBool("Jump", true);
        }
        //Animation for when the player is movinng.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && canMove)
        {
            animate.SetBool("Walking", true);
        }
        else if (!Input.GetKey(KeyCode.Mouse1)) 
        { 
            //If we are not moving using WASD or mouse, stop animatioon.
            animate.SetBool("Walking", false);
        }
    }
    void PlayerMovement(float moveSpeed)
    {
        //Grab the current horizontl and vertical positions of the player.
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        //we will gather the direction and speed based on the variables multiplied by time instead of frames.
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * moveSpeed * Time.deltaTime;
        //This setting moves our player based on the value of playerMovement, using the RIGIDBODY attached to the player.
        transform.Translate(playerMovement, Space.Self);
    }
    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Ground") 
        {
            isGrounded = true;
            animate.SetBool("Jump", false);
        }
    }
}
