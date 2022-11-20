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
        if (animate.GetFloat("Xaxis") <= 0.5 && animate.GetFloat("Xaxis") >0.1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(ArcherStepLeft, 0.4f);
            print("ArcherLWalk");
        }
    }

    private void StepRWalk()
    {
        if (animate.GetFloat("Xaxis") <= 0.5 && animate.GetFloat("Xaxis") > 0.1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(ArcherStepRight, 0.4f);
            print("ArcherRWalk");
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Xaxis") < 1.2 && animate.GetFloat("Xaxis") > 0.5 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(ArcherStepRight, 0.4f);
            print("ArcherRRun");
        }
    }
    private void StepLRun()
    {
        if (animate.GetFloat("Xaxis") < 1.2f && animate.GetFloat("Xaxis") > 0.5f && animate.GetFloat("Yaxis") == 0.0f)
        {
            audioManagement.PlayOneShot(ArcherStepRight, 0.4f);
            print("ArcherLRun");
        }
    }

    private void ArcherIdle()
    {
        if (animate.GetFloat("Xaxis") < 0.1f)
        {
            audioManagement.Stop();
        }
    }

    private void ArcherDeath()
    {

    }

    private void ArcherAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(ArcherAttackSound, 0.4f);
        }
    }

    private void ArcherImpact()
    {

    }
}
