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
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            animate.SetBool("Walking", true);
        }
        else
        {
            animate.SetBool("Walking", false);
        }
    }
}
