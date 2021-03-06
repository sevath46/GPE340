using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            animate.SetTrigger("fire");
            Debug.Log("Fired");
        }
    }
}
