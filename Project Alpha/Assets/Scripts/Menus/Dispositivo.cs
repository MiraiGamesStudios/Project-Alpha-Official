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

    public AudioSource audioManagement;
    [SerializeField]
    public AudioClip buttonSound;


    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
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

    void Update()
    {
        if (!dispositivoElegido)
        {
            if (Input.touchCount > 0)
            {
                //se ha detecatado interacción con un touch 
                //se esta jugando desde móvil
                dispositivo = 0;
                dispositivoElegido = true;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                //se ha detecatado interacción con un click 
                //se esta jugando desde ordenador
                dispositivo = 1;
                dispositivoElegido = true;
            }
        }
    }

    public void ButtonStart()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        PanelSeleccionarDispositivo.SetActive(false);
        PanelEras.SetActive(true);
    }

    public void Dispositivos()
    {
        print("HOLA");
        
        if (!dispositivoElegido)
        {
            print("HOLA2");
            if (Input.touchCount > 0)
            {

                //se ha detectado interacción con un touch 
                //se esta jugando desde móvil
                dispositivo = 0;
                dispositivoElegido = true;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                //se ha detectado interacción con un click 
                //se esta jugando desde ordenador
                dispositivo = 1;
                dispositivoElegido = true;
            }
        }
    }
}