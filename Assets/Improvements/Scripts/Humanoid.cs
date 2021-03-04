using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour
{
    public float movingSpeed, health, maxHealth;

    void Start() 
    {
        maxHealth = health;
    }
}
