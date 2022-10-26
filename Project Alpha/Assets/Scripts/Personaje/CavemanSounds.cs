using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavemanSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    //[SerializeField] private AudioSource audioManagement;
    private AudioSource audioManagement;
    private Animator animate;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
        animate = GetComponent<Animator>();
    }

    private void StepRTired()
    {
        if (animate.GetFloat("Xaxis") >= 3 && animate.GetFloat("Xaxis") < 4)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("RTired");
        }

    }

    private void StepLTired()
    {
        if (animate.GetFloat("Xaxis") >= 3 && animate.GetFloat("Xaxis") < 4)
        {
            audioManagement.PlayOneShot(sounds[0], 0.4f);
            print("LTired");
        }
    }

    private void StepLWalking()
    {
        /*if (animate.GetFloat("Xaxis") > 1.06 && animate.GetFloat("Xaxis") <= 2)
        {
            if (animate.GetFloat("Yaxis") == 0)
            {
                audioManagement.PlayOneShot(sounds[1], 0.4f);
                print("LWalking");
            }
            if (animate.GetFloat("Yaxis") >= -1 && animate.GetFloat("Yaxis") < 0)
            {
                audioManagement.PlayOneShot(sounds[1], 0.4f);
                print("LLateral");
            }

            if (animate.GetFloat("Yaxis") > 0 && animate.GetFloat("Yaxis") <= 1)
            {
                audioManagement.PlayOneShot(sounds[1], 0.4f);
                print("LLateral");
            }
        }*/

        if (animate.GetFloat("Xaxis") > 1.06 && animate.GetFloat("Xaxis") <= 2.05)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("LWalking");
        }
    }

    private void StepRWalking()
    {
        /*if (animate.GetFloat("Xaxis") > 1.06 && animate.GetFloat("Xaxis") <= 2)
        {
            if (animate.GetFloat("Yaxis") == 0)
            {
                audioManagement.PlayOneShot(sounds[1], 0.4f);
                print("RWalking");
            }
            if (animate.GetFloat("Yaxis") >= -1 && animate.GetFloat("Yaxis") < 0)
            {
                audioManagement.PlayOneShot(sounds[1], 0.4f);
                print("RLateral");
            }

            if (animate.GetFloat("Yaxis") > 0 && animate.GetFloat("Yaxis") <= 1)
            {
                audioManagement.PlayOneShot(sounds[1], 0.4f);
                print("RLateral");
            }
        }*/

        if (animate.GetFloat("Xaxis") > 1.06 && animate.GetFloat("Xaxis") <= 2.05)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("RWalking");
        }
    }

    private void StepLRunning()
    {
        if (animate.GetFloat("Xaxis") > 2.1 && animate.GetFloat("Xaxis") <= 3)
        {
            audioManagement.PlayOneShot(sounds[3], 0.4f);
            print("LRunning");
        }
    }

    private void StepRRunning()
    {
        if (animate.GetFloat("Xaxis") > 2.1 && animate.GetFloat("Xaxis") <= 3)
        {
            audioManagement.PlayOneShot(sounds[3], 0.4f);
            print("RRunning");
        }
    }

    private void StepRBack()
    {
        if (animate.GetFloat("Xaxis") >= 0 && animate.GetFloat("Xaxis") < 0.90)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("RBack");
        }
    }

    private void StepLBack()
    {
        if (animate.GetFloat("Xaxis") >= 0 && animate.GetFloat("Xaxis") < 0.90)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("LBack");
        }
    }

    private void StepLIdle()
    {
        if (animate.GetFloat("Xaxis") >= 0.95 && animate.GetFloat("Xaxis") < 1.05)
        {
            audioManagement.Stop();
            print("LIdle");
        }
    }

    private void StepRIdle()
    {
        if (animate.GetFloat("Xaxis") >= 0.95 && animate.GetFloat("Xaxis") < 1.05)
        {
            audioManagement.Stop();
            print("RIdle");
        }
    }

}
