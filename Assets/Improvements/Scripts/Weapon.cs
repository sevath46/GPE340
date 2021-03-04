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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWeaponChange) 
        {
            WeaponChange();
        }
    }

    protected virtual void OnAnimatorIK()
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
    public enum EquippedWeapon
    {
        None = 0,
        Pistol = 1,
        AssaultRifle = 2,
    }
    public void WeaponChange() 
    {
        switch ((int)weaponType)
        {
            case 0:
                leftHandIKTarget = null;
                rightHandIKTarget = null;
                isWeaponChange = false;
                break;
            case 1:
                animate.SetInteger("Weapon", 1);
                isWeaponChange = false;
                Destroy(currWeapon);
                currWeapon = Instantiate(pistol, weaponSpawn.transform.position, Quaternion.identity);
                getIK(currWeapon);
                break;
            case 2:
                animate.SetInteger("Weapon", 2);
                isWeaponChange = false;
                Destroy(currWeapon);
                currWeapon = Instantiate(assaultRifle, weaponSpawn.transform.position, Quaternion.identity);
                getIK(currWeapon);
                break;
            default:
                isWeaponChange = false;
                break;
        }
    }
    public void getIK(GameObject target) 
    {
        target.transform.parent = weaponSpawn.transform;
        leftHandIKTarget = target.transform.GetChild(0);
        rightHandIKTarget = target.transform.GetChild(1);
    }
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
        isWeaponChange = true;
        return;
    }
}

