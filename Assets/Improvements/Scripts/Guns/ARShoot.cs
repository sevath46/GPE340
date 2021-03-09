using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARShoot : WeaponShoot
{
    // Start is called before the first frame update
    void Start()
    {
        animate = this.transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && this.gameObject.tag == "Player")
        {
            animate.SetTrigger("Fire");
        }
    }
}
