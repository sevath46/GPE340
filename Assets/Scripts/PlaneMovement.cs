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
            animate.SetBool("Walking", true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                this.transform.LookAt(hit.point);
                this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else
            {
                
            }
        }
    }
}
