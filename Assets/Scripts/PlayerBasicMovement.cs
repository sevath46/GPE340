using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody rb;
    private Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement(movementSpeed);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            animate.SetBool("Walking", true);
        }
        else 
        { 
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
}
