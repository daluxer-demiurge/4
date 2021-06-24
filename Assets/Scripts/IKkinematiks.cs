using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKkinematiks : MonoBehaviour
{
    [SerializeField] private Animator animatorGO;
    [SerializeField] private Transform rightHandObj;
    [SerializeField] private Transform leftHandObj;
    [SerializeField] private Transform lookObj;

    [SerializeField] private float rightHandWeight;
    [SerializeField] private float leftHandWeight;


    void Start()
    {
        animatorGO = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if(leftHandObj)
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);

            animatorGO.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
            animatorGO.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
        }

        if (rightHandObj)
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);

            animatorGO.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
            animatorGO.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
        }

        if (lookObj)
        {
            animatorGO.SetLookAtWeight(1);
            animatorGO.SetLookAtPosition(lookObj.position);
        }
    }
}
