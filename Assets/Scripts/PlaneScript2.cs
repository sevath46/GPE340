using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript2 : MonoBehaviour
{
    public GameObject player;

    public float clickablePlaneZ;

    Plane plane;

    Vector3 distanceFromCamera;

    // Start is called before the first frame update
    void Start()
    {
        distanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - clickablePlaneZ);

        plane = new Plane(Vector3.up, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float enter = 0.0f;

            if (plane.Raycast(ray, out enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                Vector3 direction = hitPoint - transform.position;

                float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

                player.transform.rotation = Quaternion.Euler(0, rotation, 0); 

            } 
        }
    }
}
