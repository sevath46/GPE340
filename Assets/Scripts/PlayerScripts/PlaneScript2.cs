using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript2 : MonoBehaviour
{
    public GameObject player;

    Plane plane;


    // Start is called before the first frame update
    void Start()
    {

        //Create the plane.
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        //Wehn we press the right mouse button
        if (Input.GetMouseButton(1))
        {
            //Cast a ray from the camera to the mouse position.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Get a float value ready.
            float enter = 0.0f;
            //If our plane is able to turn into a float
            if (plane.Raycast(ray, out enter))
            {
                //Grab the point on the plane our ray touched.
                Vector3 hitPoint = ray.GetPoint(enter);
                //Grab the direction our hitpoint is at.
                Vector3 direction = hitPoint - transform.position;

                //Rotate the player to face the mouse.
                float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

                player.transform.rotation = Quaternion.Euler(0, rotation, 0); 

            } 
        }
    }
}
