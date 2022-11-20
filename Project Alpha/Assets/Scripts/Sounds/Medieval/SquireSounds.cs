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
        if (animate.GetFloat("Xaxis") < 0.1)
        {
            audioManagement.Stop();
        }
    }

    private void SquireAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(SquireAttackSound, 0.4f);
        }
    }

    private void SquireImpact()
    {

    }

    private void SquireDeath()
    {
        if (animate.GetBool("Death") == true)
        {
            audioManagement.PlayOneShot(SquireDeathSound, 0.4f);
        }
    }

    private void StepLWalk()
    {
        if (animate.GetFloat("Xaxis") > 0.1 && animate.GetFloat("Xaxis") <= 0.6)
        {
            audioManagement.PlayOneShot(SquireStepLeft, 0.4f);
        }
    }

    private void StepRWalk()
    {
        if (animate.GetFloat("Xaxis") > 0.1 && animate.GetFloat("Xaxis") <= 0.6)
        {
            audioManagement.PlayOneShot(SquireStepRight, 0.4f);
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1)
        {
            audioManagement.PlayOneShot(SquireStepRunRight, 0.4f);
        }
    }
    private void StepLRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1)
        {
            audioManagement.PlayOneShot(SquireStepRunLeft, 0.4f);
        }
    }

}
