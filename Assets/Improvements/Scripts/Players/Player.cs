using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid
{
    void Update()
    {
        //if the players health hits 0
        if (health <= 0) 
        {
            //Kill the player.
            Destroy(this.gameObject);
        }
    }
}
