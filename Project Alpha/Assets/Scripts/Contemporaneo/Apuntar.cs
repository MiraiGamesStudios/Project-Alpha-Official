using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar : MonoBehaviour
{
    public Animator anim;
    public GameObject go;

    void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKPosition(AvatarIKGoal.RightHand, go.transform.position);
        anim.SetIKRotation(AvatarIKGoal.RightHand, go.transform.rotation);

        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, go.transform.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, go.transform.rotation);
    }
}
