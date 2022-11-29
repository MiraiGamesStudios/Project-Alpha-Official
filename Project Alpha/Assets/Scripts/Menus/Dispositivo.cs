using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dispositivo : MonoBehaviour
{
    public static Dispositivo Instance;

    public GameObject PanelEras;
    public GameObject PanelSeleccionarDispositivo;

    public bool dispositivoElegido = false;

    public int dispositivo;

    public int Language;


    private void Awake()
    {
        if (Dispositivo.Instance == null)
        {
            Dispositivo.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }

    public void ButtonMovil()
    {

        PanelSeleccionarDispositivo.SetActive(false);
        PanelEras.SetActive(true);
        dispositivo = 1;
        dispositivoElegido = true;
    }

    public void ButtonPC()
    {
        PanelSeleccionarDispositivo.SetActive(false);
        PanelEras.SetActive(true);
        dispositivo = 0;
        dispositivoElegido = true;
    }
}