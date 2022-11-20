using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private bool golpeado = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision?.gameObject.GetComponentInParent<Worker>()?.gameObject.tag == "Worker" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Worker>().quitarVida(5, "5");
            Destroy(gameObject);
        }

        if (collision?.gameObject.GetComponentInParent<Suit>()?.gameObject.tag == "Suit" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Suit>().quitarVida(5, "5");
            Destroy(gameObject);
        }

        if (collision?.gameObject.GetComponentInParent<Militar>()?.gameObject.tag == "Militar" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Militar>().quitarVida(5, "5");
            Destroy(gameObject);
        }

        if (collision?.gameObject.GetComponentInParent<Police>()?.gameObject.tag == "Policia" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Police>().quitarVida(5, "5");
            Destroy(gameObject);
        }
        if (collision?.gameObject.GetComponentInParent<Militar>()?.gameObject.tag == "Boss" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Militar>().quitarVida(5, "5");
            Destroy(gameObject);
        }
        else
        {
            golpeado = true;
            Destroy(gameObject);
        }

    }
}
