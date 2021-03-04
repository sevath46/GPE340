using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item curItem;

    public enum Item
    {
        pistol = 0,
        assaultRifle = 1,
        healthPack = 2,
    }
    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Player") 
        {
            switch ((int)curItem) 
            {
                case 0:
                    col.gameObject.GetComponent<Weapon>().weaponChange("Pistol");
                    Destroy(this.gameObject);
                    break;
                case 1:
                    col.gameObject.GetComponent<Weapon>().weaponChange("AssaultRifle");
                    Destroy(this.gameObject);
                    break;
                case 2:
                    col.gameObject.GetComponent<Player>().health += 10;
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}