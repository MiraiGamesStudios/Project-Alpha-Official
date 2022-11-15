using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip WizardStepLeft, WizardStepRight, WizardStepRunLeft, WizardStepRunRight, WizardAttackSound,
        WizardImpactSound, WizardDeathSound;
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

    private void WizardAttack()
    {

    }

    private void WizardDeath()
    {

    }

    private void WizardIdle()
    {

    }
}
