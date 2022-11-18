using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip WizardStepLeft, WizardStepRight, WizardStepRunLeft, WizardStepRunRight,
        WizardImpactSound, WizardDeathSound;
    [SerializeField]
    private AudioClip[] WizardAttackSound;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void StepLWalk()
    {
        if(animate.GetFloat("Yaxis")>0.9 && animate.GetFloat("Yaxis") <= 1.5)
        {
            audioManagement.PlayOneShot(WizardStepLeft, 0.4f);
        }
    }

    private void StepRWalk()
    {
        if (animate.GetFloat("Yaxis") > 0.9 && animate.GetFloat("Yaxis") <= 1.5)
        {
            audioManagement.PlayOneShot(WizardStepLeft, 0.4f);
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Yaxis") > 1.5 && animate.GetFloat("Yaxis") <= 2)
        {
            audioManagement.PlayOneShot(WizardStepRunRight, 0.4f);
        }
    }
    private void StepLRun()
    {
        if (animate.GetFloat("Yaxis") > 1.5 && animate.GetFloat("Yaxis") <= 2)
        {
            audioManagement.PlayOneShot(WizardStepRunLeft, 0.4f);
        }
    }

    public void WizardAttack(int hechizo)
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(WizardAttackSound[hechizo], 0.4f);
        }
        
    }

    private void WizardDeath(int hechizo)
    {
        if (animate.GetBool("Morir") == true )
        {
            audioManagement.PlayOneShot(WizardDeathSound, 0.4f);
        }
        
    }

    private void WizardIdle()
    {
        if (animate.GetFloat("Yaxis") >= 0 && animate.GetFloat("Yaxis") <=0.8)
        {
            audioManagement.Stop();
        }
    }
}
