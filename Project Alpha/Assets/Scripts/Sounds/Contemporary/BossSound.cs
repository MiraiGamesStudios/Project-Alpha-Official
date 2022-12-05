using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip BossStepLeft, BossStepRight, BossStepRunLeft, BossStepRunRight, BossImpactSound, BossDeathSound, BossAttackSound;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void StepLWalk()
    {
        if (animate.GetFloat("Yaxis") > 0.9 && animate.GetFloat("Yaxis") <= 1.5)
        {
            audioManagement.PlayOneShot(BossStepLeft, 0.4f);
        }
    }

    private void StepRWalk()
    {
        if (animate.GetFloat("Yaxis") > 0.9 && animate.GetFloat("Yaxis") <= 1.5)
        {
            audioManagement.PlayOneShot(BossStepLeft, 0.4f);
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Yaxis") > 1.5 && animate.GetFloat("Yaxis") <= 2)
        {
            audioManagement.PlayOneShot(BossStepRunRight, 0.4f);
        }
    }
    private void StepLRun()
    {
        if (animate.GetFloat("Yaxis") > 1.5 && animate.GetFloat("Yaxis") <= 2)
        {
            audioManagement.PlayOneShot(BossStepRunLeft, 0.4f);
        }
    }

    public void BossAttack(int hechizo)
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(BossAttackSound, 0.4f);
        }

    }

    private void BossDeath(int hechizo)
    {
        if (animate.GetBool("Morir") == true)
        {
            audioManagement.PlayOneShot(BossDeathSound, 0.4f);
        }

    }

    private void BossIdle()
    {
        if (animate.GetFloat("Yaxis") >= 0 && animate.GetFloat("Yaxis") <= 0.8)
        {
            audioManagement.Stop();
        }
    }
}
