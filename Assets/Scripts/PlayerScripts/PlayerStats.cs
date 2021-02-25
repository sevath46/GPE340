using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Basic stats our player needs 
    public float health, stamina, rechargeRate;
    //Values to hold our maximum values of health and stamina incase changes happen in game (Prepped for powerups)
    public static float StatHealth, statStamina;
    //Current stat values that can be changed during game. 
    public static float currHealth, currStamina;
    // Start is called before the first frame update
    void Start()
    {
        //at start our health and stamina will be set as current based on inspector value.
        currHealth = health;
        currStamina = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        //We will recharge our stamina every update by a specified rechargeRate
        currStamina = StaminaRecharge(rechargeRate);
        //Set our current health and stamina values based on the values of our current health and stamina divided by max health and stamina.
        StatHealth = currHealth / health;
        statStamina = currStamina / stamina;
    }
    //function to recharge stamina
    float StaminaRecharge(float rate) 
    {
        //if our stamina is less than our max stamina
        if (currStamina < stamina)
        {
            //start the recharge and return our new currstamina.
            currStamina = currStamina + rate;
            return currStamina;
        }
        //otherwise we will simply return the current stamina value.
        else 
        {
            return currStamina;
        }
    }
}
