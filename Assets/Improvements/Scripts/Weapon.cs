using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject assaultRifle, weaponSpawn, currWeapon;
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
                isWeaponChange = false;
                break;
            case 2:
                animate.SetInteger("Weapon", 2);
                isWeaponChange = false;
                currWeapon = Instantiate(assaultRifle, weaponSpawn.transform.position, weaponSpawn.transform.rotation);
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
}

