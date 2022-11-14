using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip ArcherStepLeft, ArcherStepRight, ArcherStepRunLeft, ArcherStepRunRight, ArcherAttackSound, ArcherImpactSound,
        ArcherDeathSound;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
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

    private void ArcherIdle()
    {

    }

    private void ArcherDeath()
    {

    }

    private void ArcherAttack()
    {

    }

    private void ArcherImpact()
    {

    }
}
