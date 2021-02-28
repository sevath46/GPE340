using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public bool canShoot;
    public GameObject pistolBullet, rifleBullet, pistolBarrel, rifleBarrel;
    public float pistolBulletSpeed, rifleBulletSpeed, pistolFireRate, assaultRifleFireRate;
    public Animator pistolAnimation;


    public Transform leftHandIKTarget, rightHandIKTarget;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)WeaponType.playerWeaponType == 0)
        {
            
        }
        else if ((int)WeaponType.playerWeaponType == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)&& canShoot)
            {
                canShoot = false;
                StartCoroutine(WeaponFireRate(pistolFireRate));
                pistolAnimation.SetTrigger("Fire");
                GameObject instantBullet = Instantiate(pistolBullet, pistolBarrel.transform.position, Quaternion.identity) as GameObject;
                instantBullet.GetComponent<Rigidbody>().AddForce(transform.forward * pistolBulletSpeed);
            }
        }
        else if ((int)WeaponType.playerWeaponType == 2) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)&& canShoot)
            {
                canShoot = false;
                StartCoroutine(WeaponFireRate(assaultRifleFireRate));
                for (int i = 0; i < 3; i++)
                {
                    StartCoroutine(WeaponBulletRate(0.1f));
                }
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
    IEnumerator WeaponFireRate(float delay) 
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
    IEnumerator WeaponBulletRate(float delay) 
    {

        yield return new WaitForSeconds(delay);
        this.GetComponent<Animator>().SetTrigger("Fire");
        GameObject instantBullet = Instantiate(rifleBullet, rifleBarrel.transform.position, Quaternion.identity) as GameObject;
        instantBullet.GetComponent<Rigidbody>().AddForce(transform.forward * rifleBulletSpeed);
    }
}
