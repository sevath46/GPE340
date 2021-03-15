using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //When the bullet collides with something
    void OnTriggerEnter(Collider col) 
    {
        //if collision is an enemy.
        if (col.gameObject.tag == "Enemy") 
        {
            //Grab the health value and decrease it
            col.gameObject.GetComponent<Enemy>().health--;
            //Destroy the bullet
            Destroy(this.gameObject);
        }
        //if the collision is a player.
        if (col.gameObject.tag == "Player") 
        {
            //Grab the health value and decrease it
            col.gameObject.GetComponent<Player>().health--;
            //Destroy the bullet
            Destroy(this.gameObject);
        }
    }
}
