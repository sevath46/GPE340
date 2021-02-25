using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    //Var for the Stamina slider
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the slider at startup
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the value of our slider based on the variable of statStamina inside the PlayerStats script.
        slider.value = PlayerStats.statStamina;
    }
}
