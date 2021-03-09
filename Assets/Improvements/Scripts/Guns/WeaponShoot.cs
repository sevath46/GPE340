using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public float shootRate;
    public GameObject barrel, bullet;
    public float bulletSpeed;
    public Animator animate;


    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
