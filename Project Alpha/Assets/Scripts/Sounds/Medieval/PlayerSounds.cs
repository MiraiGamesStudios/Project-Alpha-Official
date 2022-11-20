using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip PlayerStepLeft, PlayerStepRight, PlayerRunStepLeft, PlayerRunStepRight,
        PlayerSwordAttack, PlayerCrossbowAttack, PlayerBowAttack, PlayerDeath;

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
        if (animate.GetFloat("Yaxis") > 0.11f && animate.GetFloat("Yaxis") <= 1.0f)
        {
            audioManagement.PlayOneShot(PlayerStepLeft, 0.4f);
            print("LWalkingrect");
        }

        //Lateral Dcha
        if (animate.GetFloat("Xaxis") > 0.25f && animate.GetFloat("Xaxis") <= 1.0f)
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

    private void StepRWalk()
    {
        //Recto
        if (animate.GetFloat("Yaxis") > 0.11f && animate.GetFloat("Yaxis") <= 1.0f)
        {
            audioManagement.PlayOneShot(PlayerStepRight, 0.4f);
            print("RWalkingrect");
        }

        //Lateral Dcha
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

    private void SwordAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            if(animate.GetInteger("ArmaElegida") == 0)
            {
                audioManagement.PlayOneShot(PlayerSwordAttack, 0.4f);
            }
        }
    }

    private void CrossbowAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            if (animate.GetInteger("ArmaElegida") == 2)
            {
                audioManagement.PlayOneShot(PlayerCrossbowAttack, 0.4f);
            }
        }
    }

    private void BowAttack()
    {
        if (animate.GetBool("Atacar") == true)
        {
            if (animate.GetInteger("ArmaElegida") == 1)
            {
                audioManagement.PlayOneShot(PlayerBowAttack, 0.4f);
            }
        }
    }

    private void PlayerIdle()
    {
        if (animate.GetFloat("Yaxis") > -0.1f && animate.GetFloat("Yaxis") < 0.1f && animate.GetFloat("Xaxis") > -0.1f && animate.GetFloat("Xaxis") < 0.1f)
        {
            audioManagement.Stop();
        }
    }

}
