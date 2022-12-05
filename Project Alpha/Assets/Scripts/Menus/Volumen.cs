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

    public void pantallaVolumen()
    {
        if (idioma.Language == 0)
        {
            menuVolumen.SetActive(true);
            menuVolumenESP.SetActive(true);
            menuPausa.SetActive(false);
        }
        if (idioma.Language == 1)
        {
            menuVolumen.SetActive(true);
            menuVolumenENG.SetActive(true);
            menuPausa.SetActive(false);
        }

        
    }

        public void volverPausa()
        {
            menuVolumen.SetActive(false);
            menuPausa.SetActive(true);
        }
    }

