using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject menuPausa;
    public GameObject menuPausaESP;
    public GameObject menuPausaENG;
    public CambiarIdioma ControladorIdioma;

    public void pausa()
    {
        Time.timeScale = 0f;
        if (ControladorIdioma.Language == 0)
        {
            botonPausa.SetActive(false);
            menuPausa.SetActive(true);
            menuPausaESP.SetActive(true);   
        }
        if (ControladorIdioma.Language == 1)
        {
            botonPausa.SetActive(false);
            menuPausa.SetActive(true);
            menuPausaENG.SetActive(true);
        }
    }

    public void reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
