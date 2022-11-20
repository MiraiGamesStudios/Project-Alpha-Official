using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip WorkerStepRight, WorkerStepLeft, WorkerImpactSound, WorkerAttackSound, WorkerDeathSound;
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
            audioManagement.PlayOneShot(WorkerStepLeft, 0.4f);
        }
    }

    private void StepRWalk()
    {
        if (animate.GetFloat("Xaxis") > 0.2 && animate.GetFloat("Xaxis") <= 0.55)
        {
            audioManagement.PlayOneShot(WorkerStepRight, 0.4f);
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1.1)
        {
            audioManagement.PlayOneShot(WorkerStepRight, 0.4f);
        }
    }
    private void StepLRun()
    {
        if (animate.GetFloat("Xaxis") > 0.6 && animate.GetFloat("Xaxis") <= 1.1)
        {
            audioManagement.PlayOneShot(WorkerStepLeft, 0.4f);
        }
    }

    private void WorkerIdle()
    {
        if(animate.GetFloat("Yaxis")>=0.0f && animate.GetFloat ("Yaxis")<0.2f
            && animate.GetFloat("Xaxis") >= 0.0f && animate.GetFloat("Xaxis") < 0.2f)
        {
            audioManagement.Stop();
        }
    }

    private void WorkerAttack()
    {
        if(animate.GetFloat("Xaxis")>1.1 && animate.GetFloat("Xaxis") <= 1.5)
        {
            audioManagement.PlayOneShot(WorkerAttackSound, 0.4f);
        }
    }

}
