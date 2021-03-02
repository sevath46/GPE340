using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public static EquippedWeapon playerWeaponType;

    // Start is called before the first frame update
    void Start()
    {
        playerWeaponType = EquippedWeapon.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum EquippedWeapon
    {
        None = 0,
        Pistol = 1,
        AssaultRifle = 2,
    }
}
