using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
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
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("TRexAttack");
        }
    }

    private void TRexDeath()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("TRexDeath");
        }
    }

    private void TRexJump()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 0.5)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print(" TRexJump");
        }
    }

    private void TRexStepRRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("TRexRRun");
        }
    }

    private void TRexStepLRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("TRexLRun");
        }
    }

    private void TRexStepRWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("TRexRWalk");
        }
    }

    private void TRexStepLWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("TRexLWalk");
        }
    }
}
