using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumen : MonoBehaviour
{
    public GameObject menuVolumen;
    public GameObject menuPausa;

    public void pantallaVolumen()
    {
        menuVolumen.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void volverPausa()
    {
        menuVolumen.SetActive(false);
        menuPausa.SetActive(true);
    }
}

