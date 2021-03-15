using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARShoot : WeaponShoot
{
    public float timeNextShotIsReady, shotsPerMinute;
    // Start is called before the first frame update

    void Awake() 
    {
        timeNextShotIsReady = Time.time; 
    }
    void Start()
    {

        animate = this.transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && this.gameObject.tag == "Player")
        {
            if (Time.time > timeNextShotIsReady)
            {
                animate.SetTrigger("Fire");
                GameObject instantBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
                instantBullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * bulletSpeed);
                Destroy(instantBullet, 2.0f);
                timeNextShotIsReady += 60f / shotsPerMinute;

            }
        }
        else if (Time.time > timeNextShotIsReady)
        {
            timeNextShotIsReady = Time.time;
        }
        if (this.gameObject.tag == "Enemy")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.root.position, transform.root.forward, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    animate.SetTrigger("Fire");
                    GameObject instantBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
                    instantBullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * bulletSpeed);
                    Destroy(instantBullet, 2.0f);
                    timeNextShotIsReady += 60f / shotsPerMinute;
                }
            }
        }
        else if (Time.time > timeNextShotIsReady)
        {
            timeNextShotIsReady = Time.time;
        }
    }
}
