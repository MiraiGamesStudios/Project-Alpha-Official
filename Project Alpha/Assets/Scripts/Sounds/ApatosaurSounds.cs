using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApatosaurSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;

    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void ApatoAttack()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("ApatoAttack");
        }
    }

    private void ApatoJump()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 0.5)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("ApatoJump");
        }
    }

    private void ApatoDeath()
    {
        if (animate.GetFloat("Xaxis") == 0 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("ApatoDeath");
        }
    }

    private void ApatoStepForwardRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("ApatoForwardRun");
        }
    }

    private void ApatoStepBackwardRun()
    {
        if (animate.GetFloat("Xaxis") == 1 && animate.GetFloat("Yaxis") == 0)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("ApatoBackwardRun");
        }
    }

    private void ApatoStepFirstWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("ApatoFirstWalk");
        }
    }

    private void ApatoStepSecondWalk()
    {
        if (animate.GetFloat("Xaxis") == 0.5 && animate.GetFloat("Yaxis") == 1)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("ApatoSecondWalk");
        }
    }
}
