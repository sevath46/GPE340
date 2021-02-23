using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float m_DistanceZ;
    Plane plane;
    Vector3 m_DistanceFromCamera;
    // Start is called before the first frame update
    void Start()
    {
        m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

        plane = new Plane(Vector3.forward, m_DistanceFromCamera);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0.0f;
            if (plane.Raycast(ray, out enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                var playerPosition = plane.ClosestPointOnPlane(this.GetComponent<Transform>().position);
                this.GetComponent<Transform>().rotation = Quaternion.LookRotation(hitPoint - playerPosition);
            }
        }
    }
}
