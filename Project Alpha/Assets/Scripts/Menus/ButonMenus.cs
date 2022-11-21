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
    public GameObject PanelEras;
    public GameObject PanelSeleccionarDispositivo;
    public GameObject ScriptDispositivo;

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
        Controles.SetActive(true);
    }

    public void ButtonCreditos()
    {
        Creditos.SetActive(true);
    }

    public void ButtonVoler()
    {
        Controles.SetActive(false);
        Creditos.SetActive(false);

    }

    public void CambiarEscena(int indice)
    {
        SceneManager.LoadScene(indice);
        Time.timeScale = 1;
    }

    public void ReiniciarPartida(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    


}
