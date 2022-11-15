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
        //animate.
    }

    private void StepLTired()
    {

    }

    private void StepLWalk()
    {

    }

    private void StepRWalk()
    {

    }

    private void StepLRun()
    {


    }

    private void StepRRun()
    {

    }

    private void SwordAttack()
    {

    }

    private void CrossbowAttack()
    {

    }

    private void BowAttack()
    {

    }

    private void PlayerIdle()
    {

    }

}
