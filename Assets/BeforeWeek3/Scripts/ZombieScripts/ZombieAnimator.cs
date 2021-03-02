using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<ZombieStats>().health == 0)
        {
            animate.SetBool("Death", true);
        }
        else 
        {
            animate.SetBool("Death", false);
        }
    }
}
