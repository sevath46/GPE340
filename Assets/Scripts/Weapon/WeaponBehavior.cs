using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public string currWeapon;
    public GameObject pistolBullet, rifleBullet;
    public float pistolBulletSpeed, rifleBulletSpeed;
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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                this.GetComponent<Animator>().SetTrigger("Fire");
                GameObject instantBullet = Instantiate(pistolBullet, transform.position, Quaternion.identity) as GameObject;
                instantBullet.GetComponent<Rigidbody>().AddForce(transform.forward * pistolBulletSpeed);
            }
        }
        else if ((int)WeaponType.playerWeaponType == 2) 
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                this.GetComponent<Animator>().SetTrigger("Fire");
            }
        }
    }
}
