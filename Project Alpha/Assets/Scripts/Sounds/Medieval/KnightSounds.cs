using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip KnightStepLeft, KnightStepRight, KnightStepRunLeft, KnightStepRunRight, KnightAttackSound, KnightImpactSound,
        KnightDeathSound, KnightFurySound;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void KnightDeath()
    {

    }

    private void KnightFury()
    {

    }

    private void KnightAttack()
    {

    }

    private void KnightImpact()
    {

    }

    private void KnightIdle()
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
