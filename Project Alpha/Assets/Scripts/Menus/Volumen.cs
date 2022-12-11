using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumen : MonoBehaviour
{
    [SerializeField] public CambiarIdioma idioma;
    public GameObject menuVolumen;
    public GameObject menuVolumenESP;
    public GameObject menuVolumenENG;
    public GameObject menuPausa;
    public AudioSource audioManagement;
    [SerializeField]
    public AudioClip buttonSound;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
    }

    public void pantallaVolumen()
    {
        if (idioma.Language == 0)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuVolumen.SetActive(true);
            menuVolumenESP.SetActive(true);
            menuPausa.SetActive(false);
        }
        if (idioma.Language == 1)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuVolumen.SetActive(true);
            menuVolumenENG.SetActive(true);
            menuPausa.SetActive(false);
        }

        
    }

        public void volverPausa()
        {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        menuVolumen.SetActive(false);
            menuPausa.SetActive(true);
        }
    }

