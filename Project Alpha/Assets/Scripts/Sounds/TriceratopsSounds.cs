using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriceratopsSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void TriceAttack()
    {

    }

    private void TriceDeath()
    {

    }

    private void TriceJumpFall()
    {

    }

    private void TriceStepForwardRun()
    {

    }

    private void TriceStepBackwardRun()
    {

    }

    private void TriceStepForwardWalk()
    {

    }

    private void TriceStepBackwardWalk()
    {

    }
}
