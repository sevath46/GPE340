using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Tooltip("The max speed of the player")]
    private float speed, runSpeed, currSpeed;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1f);
        input *= currSpeed;
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.z);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currSpeed = runSpeed;
        } else
        {
            currSpeed = speed;
        }
    }
}