using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajustes : MonoBehaviour
{
    public GameObject menuAjustes;
    public GameObject menuAjustesESP;
    public GameObject menuAjustesENG;
    public GameObject menuGrafico;
    public GameObject menuGraficoESP;
    public GameObject menuGraficoENG;
    public GameObject menuAudio;
    public GameObject menuAudioESP;
    public GameObject menuAudioENG;
    public GameObject menuPausa;
    public CambiarIdioma ControladorIdioma;
    public AudioSource audioManagement;
    [SerializeField]
    public AudioClip buttonSound;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
    }
    public void settings()
    {
        if (ControladorIdioma.Language == 0)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuPausa.SetActive(false);
            menuAjustes.SetActive(true);
            menuAjustesESP.SetActive(true);
        }
        if (ControladorIdioma.Language == 1)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuPausa.SetActive(false);
            menuAjustes.SetActive(true);
            menuAjustesENG.SetActive(true);
        }
    }
    public void graficos()
    {

        if (ControladorIdioma.Language == 0)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuAjustes.SetActive(false);
            menuGrafico.SetActive(true);
            menuGraficoESP.SetActive(true);
        }
        if (ControladorIdioma.Language == 1)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuAjustes.SetActive(false);
            menuGrafico.SetActive(true);
            menuGraficoENG.SetActive(true);
        }
    }

    public void audio()
    {
        Time.timeScale = 0f;
        if (ControladorIdioma.Language == 0)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuAjustes.SetActive(false);
            menuAudio.SetActive(true);
            menuAudioESP.SetActive(true);
        }
        if (ControladorIdioma.Language == 1)
        {
            audioManagement.PlayOneShot(buttonSound, 0.8f);
            menuAjustes.SetActive(false);
            menuAudio.SetActive(true);
            menuAudioENG.SetActive(true);
        }
    }

    public void volverAudio()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        menuAudio.SetActive(false);
        menuAjustes.SetActive(true);
    }

    public void volverGráficos()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        menuGrafico.SetActive(false);
        menuAjustes.SetActive(true);
    }

    public void volverAjustes()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        menuAjustes.SetActive(false);
        menuPausa.SetActive(true);
    }
}
