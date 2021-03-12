using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : WeaponShoot
{
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
            GameObject instantBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            instantBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            Destroy(instantBullet, 2.0f);
        }
        else if (this.gameObject.tag == "Enemy")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    animate.SetTrigger("Fire");
                    GameObject instantBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
                    instantBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
                    Destroy(instantBullet, 2.0f);
                }
            }
            else
            {
            }
        }
    }
}
