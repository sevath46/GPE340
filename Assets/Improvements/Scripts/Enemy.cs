using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid
{
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        ragDoll(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (health <= 0)
        {
            //TEMPORARY PERMAKILL
            Destroy(this.gameObject);
            /*
            ragDoll(false);
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(Respawn());
            GetComponent<Rigidbody>().useGravity = false;
            */

        }
    }
    public void ragDoll(bool status) 
    {
        int i;
        Rigidbody[] childRBs = GetComponentsInChildren<Rigidbody>();
        if (status == true) 
        {
            for (i = 0; i < childRBs.Length; i++) 
            {
                childRBs[i].isKinematic = true;
            }
        }
        if (status == false)
        {
            for (i = 0; i < childRBs.Length; i++)
            {
                childRBs[i].isKinematic = false;
            }
        }
    }
}
