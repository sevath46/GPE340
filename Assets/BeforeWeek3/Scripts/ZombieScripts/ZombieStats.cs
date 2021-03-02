using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : MonoBehaviour
{
    Vector3 originalPos;
    public float respawnTime;
    public int health;
    private int origHealth;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        origHealth = health;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (health < 1) 
        {
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(Respawn());
            GetComponent<Rigidbody>().useGravity = false;

        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        health = origHealth;
        gameObject.transform.position = originalPos;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
