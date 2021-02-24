using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float viewRange;
    public int moveSpeed;
    public GameObject target;
    private Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= viewRange)
        {
            animate.SetBool("Walk", true);
            transform.LookAt(target.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            animate.SetBool("Walk", false);
        }
    }
}
