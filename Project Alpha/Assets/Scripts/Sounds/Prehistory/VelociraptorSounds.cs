using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelociraptorSounds : MonoBehaviour
{
    [SerializeField] private AudioClip VelocSoundAttack, VelocSoundDeath, VelocSoundStepRun, VelocSoundStepWalk, VelocSoundStepRun2, VelocSoundStepWalk2;
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
            audioManagement.PlayOneShot(VelocSoundAttack, 0.4f);
            print("VelocAttack");
        }
    }

    private void VelocDeath()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(VelocSoundDeath, 0.4f);
            print("VelocDeath");
        }
    }


    private void VelocStepLRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(VelocSoundStepRun, 0.4f);
            print("VelocLRun");
        }
    }

    private void VelocStepRRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(VelocSoundStepRun2, 0.4f);
            print("VelocRRun");
        }
    }

    private void VelocStepLWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(VelocSoundStepWalk, 0.4f);
            print("VelocLWalk");
        }
    }

    private void VelocStepRWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(VelocSoundStepWalk2, 0.4f);
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
