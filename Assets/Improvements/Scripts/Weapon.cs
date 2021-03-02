using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animate;
    public Transform leftHandIKTarget, rightHandIKTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            animate.SetTrigger("Fire");
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
}
