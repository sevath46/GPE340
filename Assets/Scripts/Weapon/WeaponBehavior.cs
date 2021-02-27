using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public string currWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currWeapon = "none";
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)WeaponType.playerWeaponType == 0)
        {

        }
        else if ((int)WeaponType.playerWeaponType == 1)
        {
            Debug.Log("Fire weapon 1.");
        }
        else if ((int)WeaponType.playerWeaponType == 2) 
        {
            Debug.Log("Fire weapon 2.");
        }
    }
}
