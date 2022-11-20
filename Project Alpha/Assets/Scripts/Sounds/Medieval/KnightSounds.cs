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
        if (animate.GetBool("Morir") == true)
        {
            audioManagement.PlayOneShot(KnightDeathSound, 0.4f);
        }
    }

    private void KnightFury()
    {

    }

    private void KnightAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(KnightAttackSound, 0.4f);
        }
    }

    private void KnightImpact()
    {

    }

    private void KnightIdle()
    {
        if (animate.GetFloat("Xaxis") < 0.2)
        {
            audioManagement.Stop();
        }
    }

    private void StepLWalk()
    {
        if(animate.GetFloat("Xaxis")>0.1 && animate.GetFloat("Xaxis") <= 0.6)
        {
            audioManagement.PlayOneShot(KnightStepLeft, 0.4f);
        }
    }

    private void StepRWalk()
    {
        if (animate.GetFloat("Xaxis") > 0.1 && animate.GetFloat("Xaxis") <= 0.6)
        {
            audioManagement.PlayOneShot(KnightStepRight, 0.4f);
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1)
        {
            audioManagement.PlayOneShot(KnightStepRunRight, 0.4f);
        }
    }
    private void StepLRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1)
        {
            audioManagement.PlayOneShot(KnightStepRunLeft, 0.4f);
        }
    }
}
