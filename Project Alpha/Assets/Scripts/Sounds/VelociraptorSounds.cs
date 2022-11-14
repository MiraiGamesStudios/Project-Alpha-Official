using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelociraptorSounds : MonoBehaviour
{
    [SerializeField] private AudioClip soundAttack, soundDeath, soundStepRun, soundStepWalk;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void VelocAttack()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") ==1)
        {
            audioManagement.PlayOneShot(soundAttack, 0.4f);
            print("VelocAttack");
        }
    }

    private void VelocDeath()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(soundDeath, 0.4f);
            print("VelocDeath");
        }
    }


    private void VelocStepLRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(soundStepRun, 0.4f);
            print("VelocLRun");
        }
    }

    private void VelocStepRRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(soundStepRun, 0.4f);
            print("VelocRRun");
        }
    }

    private void VelocStepLWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(soundStepWalk, 0.4f);
            print("VelocLWalk");
        }
    }

    private void VelocStepRWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(soundStepWalk, 0.4f);
            print("VelocRWalk");
        }
    }

    private void VelocIdle()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.Stop();
        }
    }
}
