using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquireSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip SquireStepLeft, SquireStepRight, SquireStepRunLeft, SquireStepRunRight, SquireAttackSound, SquireImpactSound,
        SquireDeathSound;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void SquireIdle()
    {

    }

    private void SquireAttack()
    {

    }

    private void SquireImpact()
    {

    }

    private void SquireDeath()
    {

    }

    private void StepLWalk()
    {

    }

    private void StepRWalk()
    {

    }

    private void StepRRun()
    {

    }
    private void StepLRun()
    {

    }

}
