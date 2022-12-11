using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private bool golpeado = false;
    public int arma;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision?.gameObject.GetComponentInParent<Worker>()?.gameObject.tag == "Worker" && golpeado == false)
        {
            if (arma == 0)
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Worker>().quitarVida(10, "10");
                Destroy(gameObject);
            }
            else
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Worker>().quitarVida(2, "2");
                Destroy(gameObject);
            }
            
        }

        if (collision?.gameObject.GetComponentInParent<Suit>()?.gameObject.tag == "Suit" && golpeado == false)
        {
            if(arma == 0)
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Suit>().quitarVida(10, "10");
                Destroy(gameObject);
            }
            else
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Suit>().quitarVida(2, "2");
                Destroy(gameObject);
            }
           
        }

        if (collision?.gameObject.GetComponentInParent<Militar>()?.gameObject.tag == "Militar" && golpeado == false)
        {
            if (arma == 0)
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Militar>().quitarVida(10, "10");
                Destroy(gameObject);
            }
            else
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Militar>().quitarVida(2, "2");
                Destroy(gameObject);
            }
        }

        if (collision?.gameObject.GetComponentInParent<Police>()?.gameObject.tag == "Policia" && golpeado == false)
        {
            if (arma == 0)
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Police>().quitarVida(10, "10");
                Destroy(gameObject);
            }
            else
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Police>().quitarVida(2, "2");
                Destroy(gameObject);
            }
        }
        if (collision?.gameObject.GetComponentInParent<Militar>()?.gameObject.tag == "Boss" && golpeado == false)
        {
            if (arma == 0)
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Militar>().quitarVida(10, "10");
                Destroy(gameObject);
            }
            else
            {
                golpeado = true;
                collision.gameObject.GetComponentInParent<Militar>().quitarVida(2, "2");
                Destroy(gameObject);
            }
        }
        else
        {
            golpeado = true;
            Destroy(gameObject);
        }

    }
}
