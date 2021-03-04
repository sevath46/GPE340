using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid
{
    Vector3 originalPos;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        maxHealth = health;
        ragDoll(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (health <= 0)
        {
            ragDoll(false);
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(Respawn());
            GetComponent<Rigidbody>().useGravity = false;

        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        health = maxHealth;
        gameObject.transform.position = originalPos;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        ragDoll(true);
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
