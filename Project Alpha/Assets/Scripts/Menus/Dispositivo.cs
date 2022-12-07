using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dispositivo : MonoBehaviour
{
    public static Dispositivo Instance;

    public GameObject PanelEras;
    public GameObject PanelSeleccionarDispositivo;
    public Button buttonStart;

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
        if (!dispositivoElegido)
        {
            if(Input.touchCount > 0)
            {
                //se ha detecatado interacción con un touch 
                //se esta jugando desde móvil
                dispositivo = 1;
                dispositivoElegido = true;
            }
            else if(Input.GetMouseButtonDown(0))
            {
                //se ha detecatado interacción con un click 
                //se esta jugando desde ordenador
                dispositivo = 0;
                dispositivoElegido = true;
            }
        }
    }

    public void ButtonStart()
    {
        PanelSeleccionarDispositivo.SetActive(false);
        PanelEras.SetActive(true);
        dispositivoElegido = true;
    }
}