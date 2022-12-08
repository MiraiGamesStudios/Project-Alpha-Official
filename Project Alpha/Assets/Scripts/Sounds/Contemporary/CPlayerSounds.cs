using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip PlayerStepLeft, PlayerStepRight, PlayerRunStepLeft, PlayerRunStepRight,
        PlayerRifleAttack, PlayerGunAttack, PlayerRPGAttack, PlayerRPGImpact, PlayerDeathSound;

    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void StepRTired()
    {
        if (animate.GetFloat("Multiplicador") == 0.5f)
        {
            if (animate.GetFloat("Yaxis") > 0.11f && animate.GetFloat("Yaxis") <= 1.0f)
            {
                audioManagement.PlayOneShot(PlayerStepRight, 0.4f);
                print("RTired");
            }
        }
    }

    private void StepLTired()
    {
        if (animate.GetFloat("Multiplicador") == 0.5)
        {
            if (animate.GetFloat("Yaxis") > 0.11f && animate.GetFloat("Yaxis") <= 1.0f)
            {
                audioManagement.PlayOneShot(PlayerStepLeft, 0.4f);
                print("LTired");
            }
        }
    }

    private void StepLWalk()
    {
        //Recto
        if (animate.GetFloat("Yaxis") > 0.1f && animate.GetFloat("Yaxis") <= 1.1f && animate.GetFloat("Multiplicador") == 2)
        {
            audioManagement.PlayOneShot(PlayerStepLeft, 0.4f);
            print("LWalkRect");
        }


    }

    private void StepRWalk()
    {

        //Recto
        if (animate.GetFloat("Yaxis") > 0.1f && animate.GetFloat("Yaxis") <= 1.1f && animate.GetFloat("Multiplicador") == 2)
        {
            audioManagement.PlayOneShot(PlayerStepRight, 0.4f);
            print("RWalkRect");
        }


    }

    private void StepLLatWalk()
    {
        //LateralDcha
        if (animate.GetFloat("Xaxis") > 0.2f && animate.GetFloat("Xaxis") <= 1.0f)
        {
            audioManagement.PlayOneShot(PlayerStepLeft, 0.4f);
            print("LWalkingdcha");
        }

        //Lateral Izqda
        if (animate.GetFloat("Xaxis") >= (-1.0f) && animate.GetFloat("Xaxis") < -0.25f)
        {
            audioManagement.PlayOneShot(PlayerStepLeft, 0.4f);
            print("LWalkingizqda");
        }
    }

    private void StepRLatWalk()
    {
        if (animate.GetFloat("Xaxis") > 0.2f && animate.GetFloat("Xaxis") <= 1.0f)
        {
            audioManagement.PlayOneShot(PlayerStepRight, 0.4f);
            print("RWalkingdcha");
        }

        //Lateral Izqda
        if (animate.GetFloat("Xaxis") >= (-1.0f) && animate.GetFloat("Xaxis") < -0.25f)
        {
            audioManagement.PlayOneShot(PlayerStepRight, 0.4f);
            print("RWalkingizqda");
        }
    }

    private void StepLRun()
    {

        if (animate.GetFloat("Yaxis") > 1.0f && animate.GetFloat("Yaxis") <= 2.0f && animate.GetFloat("Multiplicador") == 4)
        {
            audioManagement.PlayOneShot(PlayerRunStepLeft, 0.4f);
            print("LRunning");
        }
    }

    private void StepRRun()
    {
        if (animate.GetFloat("Yaxis") > 1.0f && animate.GetFloat("Yaxis") <= 2.0f && animate.GetFloat("Multiplicador") == 4)
        {
            audioManagement.PlayOneShot(PlayerRunStepLeft, 0.4f);
            print("RRunning");
        }
    }

    public void RPGAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(PlayerRPGAttack, 0.4f);
        }
    }

    public void GunAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(PlayerGunAttack, 0.4f);
        }
    }

    public void RifleAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            audioManagement.PlayOneShot(PlayerRifleAttack, 0.4f);
        }
    }

    private void PlayerIdle()
    {
        if (animate.GetFloat("Yaxis") > -0.1f && animate.GetFloat("Yaxis") < 0.1f && animate.GetFloat("Xaxis") > -0.1f && animate.GetFloat("Xaxis") < 0.1f)
        {
            audioManagement.Stop();
        }
    }

    private void PlayerDeath()
    {

    }

    public void RPGImpact()
    {
        audioManagement.PlayOneShot(PlayerRPGImpact, 0.4f);
    }
}
