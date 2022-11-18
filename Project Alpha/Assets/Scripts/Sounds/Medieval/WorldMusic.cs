using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMusic : MonoBehaviour
{
    private AudioSource audioManagement;
    [SerializeField] private AudioClip finalMusic;
    [SerializeField] private GameObject camera;
    
    // Start is called before the first frame update
    private void Awake()
    {
        audioManagement = camera.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other?.gameObject.tag== "Player")
        {
            audioManagement.Stop();
            audioManagement.PlayOneShot(finalMusic, 0.75f);
            audioManagement.loop = true;
        }
    }
}
