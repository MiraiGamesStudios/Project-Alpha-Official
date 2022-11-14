using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriceratopsSounds : MonoBehaviour
{
    [SerializeField] private AudioClip soundAttack, soundDeath, soundStepRun, soundStepWalk;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void TriceAttack()
    {
        if (animate.GetFloat("Yaxis") > 0.2 && animate.GetFloat("Yaxis") <= 1 &&
            animate.GetFloat("Xaxis") > 0.5 && animate.GetFloat("Xaxis") <= 1)
        {
            audioManagement.PlayOneShot(soundAttack, 0.2f);
            print("TriceAttack");
        }
    }

    private void TriceDeath()
    {
        if (animate.GetFloat("Yaxis") > 0 && animate.GetFloat("Yaxis") <= 0.5 && animate.GetFloat("Xaxis") <= 0.5)
        {
            audioManagement.PlayOneShot(soundDeath, 0.3f);
            print("TriceDeath");
        }
    }

    private void TriceStepForwardRun()
    {
        if (animate.GetFloat("Xaxis") > 0.5 && animate.GetFloat("Xaxis") <= 1 && animate.GetFloat("Yaxis") <= 0.5)
        {
            audioManagement.PlayOneShot(soundStepRun, 0.2f);
            print("TriceFRun");
        }
    }

    private void TriceStepBackwardRun()
    {
        if (animate.GetFloat("Xaxis") > 0.5 && animate.GetFloat("Xaxis") <= 1 && animate.GetFloat("Yaxis") <= 0.5)
        {
            audioManagement.PlayOneShot(soundStepRun, 0.2f);
            print("TriceBRun");
        }
    }

    private void TriceStepForwardWalk()
    {
        if (animate.GetFloat("Xaxis") > 0 && animate.GetFloat("Xaxis") <= 0.5 && animate.GetFloat("Yaxis") <= 0.5)
        {
            audioManagement.PlayOneShot(soundStepWalk, 0.2f);
            print("TriceFWalk");
        }
    }

    private void TriceStepBackwardWalk()
    {
        if (animate.GetFloat("Xaxis") > 0 && animate.GetFloat("Xaxis") <= 0.5 && animate.GetFloat("Yaxis") <= 0.5)
        {
            audioManagement.PlayOneShot(soundStepWalk, 0.2f);
            print("TriceBWalk");
        }
    }

    private void TriceIdle()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.Stop();
        }
    }
}
