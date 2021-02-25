using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health, stamina, rechargeRate;
    public static float StatHealth, statStamina;
    public static float currHealth, currStamina;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = health;
        currStamina = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        currStamina = StaminaRecharge(rechargeRate);
        StatHealth = currHealth / health;
        statStamina = currStamina / stamina;
    }
    float StaminaRecharge(float rate) 
    {
        if (currStamina < stamina)
        {
            currStamina = currStamina + rate;
            return currStamina;
        }
        else 
        {
            return currStamina;
        }
    }
}
