using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public static float StatHealth;
    // Start is called before the first frame update
    void Start()
    {
        StatHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
