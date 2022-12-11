using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ButonMenus : MonoBehaviour
{
    public static ButonMenus Instance;

    public GameObject MainMenu;
    public GameObject Controles;
    public GameObject Creditos;
    public GameObject Historia;
    public GameObject PanelEras;
    public GameObject PanelSeleccionarDispositivo;
    public GameObject ScriptDispositivo;
    public AudioSource audioManagement;
    [SerializeField]
    public AudioClip buttonSound;

    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main Menu"))
        {
            if (FindObjectOfType<Dispositivo>().dispositivoElegido == true)
            {
                PanelSeleccionarDispositivo?.SetActive(false);
                PanelEras?.SetActive(true);
            }
        }
        
    }

    public void ButtonControles()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        Controles.SetActive(true);
    }

    public void ButtonCreditos()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        Creditos.SetActive(true);
    }

    public void ButtonHistoria()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        Historia.SetActive(true);
    }

    public void ButtonVoler()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        Controles.SetActive(false);
        Creditos.SetActive(false);
        Historia.SetActive(false);

    }

    public void CambiarEscena(int indice)
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        SceneManager.LoadScene(indice);
        Time.timeScale = 1;
    }

    public void ReiniciarPartida(int indice)
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        SceneManager.LoadScene(indice);
    }

    


}
