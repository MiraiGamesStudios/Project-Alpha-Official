using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip PlayerStepLeft, PlayerStepRight, PlayerRunStepLeft, PlayerRunStepRight,
        PlayerRifleAttack, PlayerGunAttack, PlayerRPGAttack, PlayerDeathSound;

    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }
}
