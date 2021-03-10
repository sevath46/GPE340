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
            GameObject instantBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            instantBullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed);
            Destroy(instantBullet, 2.0f);
        }
    }
}
