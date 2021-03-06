using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{
    public GameObject barrel;
    public float bulletSpeed;
    private Animator animate;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            animate.SetTrigger("Fire");
            GameObject instantBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            instantBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            Destroy(instantBullet, 2.0f);

        }
    }
}