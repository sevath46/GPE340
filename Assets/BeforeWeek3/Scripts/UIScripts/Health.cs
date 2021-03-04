using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    //slider variable to show health
    public GameObject player;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //grabbing slider component at start
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //set the value based on the variable of StatHealth inside script PlayerStats.
        slider.value = player.GetComponent<Player>().health / player.GetComponent<Player>().maxHealth;
    }
}
