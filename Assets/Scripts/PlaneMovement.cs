using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed;

    private Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //since we will be moving, allow the walking animation to start.
            animate.SetBool("Walking", true);

            //Instead of a plane raycast I used a normal raycast 
            //We take the position of our mouse as the target to look at and move to.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                this.transform.LookAt(hit.point);
                this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * speed * 1.5f);
                }
            }
            else
            {
                //Empty else statement.
            }
        }
    }
}
