using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid
{
    public GameObject[] spawnLocations;
    void Start() 
    {
        this.GetComponent<Weapon>().weaponChange("Pistol");
    }
    void Update()
    {
        //if the players health hits 0
        if (health <= 0) 
        {
            GameManager.GM.AdjustPlayerLives(this.gameObject);
            //Kill the player.
            this.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length)].transform.position;
            this.GetComponent<Weapon>().weaponChange("Pistol");
        }
    }
}
