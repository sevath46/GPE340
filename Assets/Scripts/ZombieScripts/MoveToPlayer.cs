using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    //Float for the eyes of the zombie
    public float viewRange;
    //how fast the zombie will move
    public int moveSpeed;
    //Who the zombie is looking for
    public GameObject target;
    //Zombie animations controller
    private Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        //grabbing animation controller at startup
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if our target is within range of our eyes
        if (Vector3.Distance(transform.position, target.transform.position) <= viewRange)
        {
            //we willl start an animation to walk
            animate.SetBool("Walk", true);
            //we will face the target
            transform.LookAt(target.transform);
            //we will moove towards the target
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            //otherwise if the target isnt in out range, we wont walk.
            animate.SetBool("Walk", false);
        }
    }
}
