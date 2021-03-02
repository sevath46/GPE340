using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //camaera target
    public GameObject player;
    //Transform of camera and target
    private Transform tf, target;
    // Start is called before the first frame update
    void Start()
    {
        //Grab transform componentss
        target = player.GetComponent<Transform>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Freeze Y axis so camera only follows on X and Z
        var actualPos = new Vector3(target.position.x, tf.position.y, target.position.z);
        //Follow player.
        tf.position = Vector3.MoveTowards(tf.position, actualPos, 1);
    }
}
