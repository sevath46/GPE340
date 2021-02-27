using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public string currWeapon;
    public GameObject pistolBullet, rifleBullet;
    public float pistolBulletSpeed, rifleBulletSpeed;
    public Animator pistolAnimation;


    public Transform leftHandIKTarget, rightHandIKTarget;
    // Start is called before the first frame update
    void Start()
    {
        currWeapon = "none";
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)WeaponType.playerWeaponType == 0)
        {

        }
        else if ((int)WeaponType.playerWeaponType == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                pistolAnimation.SetTrigger("Fire");
                GameObject instantBullet = Instantiate(pistolBullet, transform.position, Quaternion.identity) as GameObject;
                instantBullet.GetComponent<Rigidbody>().AddForce(transform.forward * pistolBulletSpeed);
            }
        }
        else if ((int)WeaponType.playerWeaponType == 2) 
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                this.GetComponent<Animator>().SetTrigger("Fire");
            }
        }
    }
    protected virtual void OnAnimatorIK() 
    {
        if ((int)WeaponType.playerWeaponType == 2) 
        {
            this.GetComponent<Animator>().SetIKPosition(AvatarIKGoal.RightHand, rightHandIKTarget.position);
            this.GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            this.GetComponent<Animator>().SetIKRotation(AvatarIKGoal.RightHand, rightHandIKTarget.rotation);
            this.GetComponent<Animator>().SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

            this.GetComponent<Animator>().SetIKPosition(AvatarIKGoal.LeftHand, leftHandIKTarget.position);
            this.GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            this.GetComponent<Animator>().SetIKRotation(AvatarIKGoal.LeftHand, leftHandIKTarget.rotation);
            this.GetComponent<Animator>().SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        }
    }
}
