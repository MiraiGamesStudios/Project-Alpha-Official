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
        if(animate.GetFloat("Multiplicador") == 0.5f)
        {
            if (animate.GetFloat("Yaxis") > 0.11f && animate.GetFloat("Yaxis") <= 1.0f)
            {
                audioManagement.PlayOneShot(sounds[1], 0.4f);
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
                audioManagement.PlayOneShot(sounds[1], 0.4f);
                print("LTired");
            }
        }
    }

    private void StepLWalking()
    {
        //Recto
        if (animate.GetFloat("Yaxis") > 0.11f && animate.GetFloat("Yaxis") <= 1.0f )
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("LWalkingrect");
        }

        //Lateral Dcha
        if (animate.GetFloat("Xaxis") > 0.25f && animate.GetFloat("Xaxis") <= 1.0f )
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("LWalkingdcha");
        }

        //Lateral Izqda
        if (animate.GetFloat("Xaxis") >= (-1.0f) && animate.GetFloat("Xaxis") < -0.25f)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("LWalkingizqda");
        }
    }

    private void StepRWalking()
    {

        //Recto
        if (animate.GetFloat("Yaxis") > 0.11f && animate.GetFloat("Yaxis") <= 1.0f)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("RWalkingrect");
        }

        //Lateral Dcha
        if (animate.GetFloat("Xaxis") > 0.2f && animate.GetFloat("Xaxis") <= 1.0f)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("RWalkingdcha");
        }

        //Lateral Izqda
        if (animate.GetFloat("Xaxis") >= (-1.0f) && animate.GetFloat("Xaxis") < -0.25f)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("RWalkingizqda");
        }
    }

    private void StepLRunning()
    {
        if (animate.GetFloat("Yaxis") > 1.0f && animate.GetFloat("Yaxis") <= 2.0f && animate.GetFloat("Multiplicador")==4)
        {
            audioManagement.PlayOneShot(sounds[3], 0.4f);
            print("LRunning");
        }
    }

    private void StepRRunning()
    {
        if (animate.GetFloat("Yaxis") > 1.0f && animate.GetFloat("Yaxis") <= 2.0f && animate.GetFloat("Multiplicador") == 4)
        {
            audioManagement.PlayOneShot(sounds[3], 0.4f);
            print("RRunning");
        }
    }

    private void StepRBack()
    {
        if (animate.GetFloat("Yaxis") > -1.0f && animate.GetFloat("Xaxis") <= 0.11f)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("RBack");
        }
    }

    private void StepLBack()
    {
        if (animate.GetFloat("Yaxis") > -1.0f && animate.GetFloat("Yaxis") <= 0.11f)
        {
            audioManagement.PlayOneShot(sounds[1], 0.4f);
            print("LBack");
        }
    }

    private void StepIdle()
    {
        if (animate.GetFloat("Yaxis") > -0.1f && animate.GetFloat("Yaxis") < 0.1f && animate.GetFloat("Xaxis") > -0.1f && animate.GetFloat("Xaxis") < 0.1f)
        {
            audioManagement.Stop();
        }

    }

}
