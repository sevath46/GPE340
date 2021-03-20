using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject assaultRifle, weaponSpawn, currWeapon, pistol;
    public  bool isWeaponChange;
    public EquippedWeapon weaponType;
    public Animator animate;
    public Transform leftHandIKTarget, rightHandIKTarget;
    public bool isPlayer;

    // Update is called once per frame
    void Update()
    {
        //Check to see if we are changing our weapon.
        if (isWeaponChange) 
        {
            //If we are start the weapon change.
            WeaponChange();
        }
    }
    //Attaches our model hands to the weapons.
    protected virtual void OnAnimatorIK()
    {
        if (!currWeapon)
        {
            animate.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            animate.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
            animate.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
            animate.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            animate.SetInteger("Weapon", 0);
        }
        else
        {
            animate.SetIKPosition(AvatarIKGoal.RightHand, rightHandIKTarget.position);
            animate.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            animate.SetIKRotation(AvatarIKGoal.RightHand, rightHandIKTarget.rotation);
            animate.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

            animate.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIKTarget.position);
            animate.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            animate.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIKTarget.rotation);
            animate.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        }
    }
    public enum EquippedWeapon
    {
        None = 0,
        Pistol = 1,
        AssaultRifle = 2,
    }
    //When the weapon changes, we set the appropriate variables across the board.
    public void WeaponChange() 
    {
        switch ((int)weaponType)
        {
            case 0:
                if (currWeapon) 
                {
                    Destroy(currWeapon.gameObject);
                }
                isWeaponChange = false;
                break;
            case 1:
                animate.SetInteger("Weapon", 1);
                isWeaponChange = false;
                Destroy(currWeapon);
                currWeapon = Instantiate(pistol, weaponSpawn.transform.position, weaponSpawn.transform.rotation);
                getIK(currWeapon);
                break;
            case 2:
                animate.SetInteger("Weapon", 2);
                isWeaponChange = false;
                Destroy(currWeapon);
                currWeapon = Instantiate(assaultRifle, weaponSpawn.transform.position, weaponSpawn.transform.rotation) as GameObject;
                getIK(currWeapon);
                break;
            default:
                isWeaponChange = false;
                break;
        }
    }
    //Grabs the IK hands from current weapon
    public void getIK(GameObject target) 
    {
        target.transform.parent = weaponSpawn.transform;
        leftHandIKTarget = target.transform.GetChild(0);
        rightHandIKTarget = target.transform.GetChild(1);
        if (isPlayer)
        {
            target.gameObject.tag = "Player";
        }
        else 
        {
            target.gameObject.tag = "Enemy";
        }
    }
    //Change enum in-game when needed via pickup script.
    public void weaponChange(string target) 
    {
        if (target == "Pistol") 
        {
            weaponType = EquippedWeapon.Pistol;
        }
        else if (target == "AssaultRifle")
        {
            weaponType = EquippedWeapon.AssaultRifle;
        }
        else if (target == "None") 
        {
            weaponType = EquippedWeapon.None;
        }
        if (isPlayer)
        {
            GameManager.GM.AdjustEquippedWeapon(target);
        }
        isWeaponChange = true;
        return;
    }
}

