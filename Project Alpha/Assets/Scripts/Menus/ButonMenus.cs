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
    public GameObject Reinicio;
    public GameObject Era1;
    public GameObject Era2;
    public GameObject Era3;
    public GameObject SelectorMovil;
    public GameObject SelectorPC;
    public GameObject PreguntaDispositivo;

    public int dispositivo;


    private void Awake()
    {
        if(ButonMenus.Instance == null)
        {
            ButonMenus.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void ReiniciarPartida(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    public void ButtonMovil()
    {
        SelectorMovil.SetActive(false);
        SelectorPC.SetActive(false);
        PreguntaDispositivo.SetActive(false);
        Era1.SetActive(true);
        Era2.SetActive(true);
        Era3.SetActive(true);
        dispositivo = 1;
        
    }

    public void ButtonPC()
    {
        SelectorMovil.SetActive(false);
        SelectorPC.SetActive(false);
        PreguntaDispositivo.SetActive(false);
        Era1.SetActive(true);
        Era2.SetActive(true);
        Era3.SetActive(true);
        dispositivo = 0;
        
    }

    
}
