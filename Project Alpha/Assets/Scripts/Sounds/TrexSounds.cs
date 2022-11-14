using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexSounds : MonoBehaviour
{
    [SerializeField] private AudioClip soundAttack, soundDeath, soundStepRun1, soundStepRun2, soundStepWalk1,
        soundStepWalk2;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void TRexAttack()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(soundAttack, 0.4f);
            print("TRexAttack");
        }
    }

    private void TRexDeath()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(soundDeath, 0.4f);
            print("TRexDeath");
        }
    }


    private void TRexStepRRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(soundStepRun1, 0.4f);
            print("TRexRRun");
        }
    }

    private void TRexStepLRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(soundStepRun2, 0.4f);
            print("TRexLRun");
        }
    }

    private void TRexStepRWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(soundStepWalk1, 0.4f);
            print("TRexRWalk");
        }
    }

    private void TRexStepLWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(soundStepWalk2, 0.4f);
            print("TRexLWalk");
        }
    }

    private void TRexIdle()
    {
        if(animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.Stop();
        }
    }
}
