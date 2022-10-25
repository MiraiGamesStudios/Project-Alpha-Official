using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    //[SerializeField] private AudioSource audioManagement;
    private AudioSource audioManagement;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
    }

    public void AudioSelection(int index,float vol)
    {
        //audioManagement.loop = true;
        //audioManagement.PlayOneShot(sounds[index], vol);
        //audioManagement.Play(0);

        if (Input.GetKeyDown("W")){
            audioManagement.PlayOneShot(sounds[1], 0.5f);
        }
    }

    public void AudioStop()
    {
        audioManagement.Stop();
    }


}
