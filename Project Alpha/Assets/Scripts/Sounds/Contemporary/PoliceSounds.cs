using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip StepLeft, StepRight, RunStepLeft, RunStepRight,
        PoliceGunAttack, PoliceDeathSound;

    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void StepLWalk()
    {
        if (animate.GetFloat("Xaxis") > 0.2 && animate.GetFloat("Xaxis") <= 0.55)
        {
            audioManagement.PlayOneShot(StepLeft, 0.4f);
        }
    }

    private void StepRWalk()
    {
        if (animate.GetFloat("Xaxis") > 0.2 && animate.GetFloat("Xaxis") <= 0.55)
        {
            audioManagement.PlayOneShot(StepRight, 0.4f);
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1)
        {
            audioManagement.PlayOneShot(StepRight, 0.4f);
        }
    }
    private void StepLRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1)
        {
            audioManagement.PlayOneShot(StepLeft, 0.4f);
        }
    }

    private void PoliceIdle()
    {
        if (animate.GetFloat("Yaxis") >= 0.0f && animate.GetFloat("Yaxis") < 0.05f
            && animate.GetFloat("Xaxis") >= 0.0f && animate.GetFloat("Xaxis") < 0.05f)
        {
            audioManagement.Stop();
        }
    }

    private void PoliceAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(PoliceGunAttack, 0.4f);
        }
    }

}
