using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavemanSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    //[SerializeField] private AudioSource audioManagement;
    private AudioSource audioManagement;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
    }

    private void StepRTired()
    {
        print("ej");
        audioManagement.PlayOneShot(sounds[1]);
    }

    private void StepLTired()
    {
        print("ej");
        audioManagement.PlayOneShot(sounds[0]);
    }

    private void StepLWalking()
    {
        print("ej");
        audioManagement.PlayOneShot(sounds[2]);
    }

    private void StepRWalking()
    {
        print("ej");
        audioManagement.PlayOneShot(sounds[3]);
    }

}
