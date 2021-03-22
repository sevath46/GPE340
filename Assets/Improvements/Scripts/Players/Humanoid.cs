using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour
{
    //Allows all humanoids to have a health variable and max health variable.
    public float health, maxHealth;

    //At the start of the the script we will keep a variable of the max health as the set health in inspector for all humanoids. 
    void Awake() 
    {
        maxHealth = health;
    }
}
