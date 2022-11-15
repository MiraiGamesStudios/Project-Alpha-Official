using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ButonMenus : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject Controles;
    public GameObject Creditos;
    public GameObject Reinicio;


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
}
