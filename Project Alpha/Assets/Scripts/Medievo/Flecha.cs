using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private bool golpeado = false;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision?.gameObject.GetComponentInParent<Caballero>()?.gameObject.tag == "Caballero" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Caballero>().quitarVida(5, "5");
        }

        if (collision?.gameObject.GetComponentInParent<Arquero>()?.gameObject.tag == "Arquero" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Arquero>().quitarVida(5, "5");
        }

        if (collision?.gameObject.GetComponentInParent<Escudero>()?.gameObject.tag == "Escudero" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Escudero>().quitarVida(5, "5");
        }

        if (collision?.gameObject.GetComponentInParent<Mago>()?.gameObject.tag == "Mago" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponentInParent<Mago>().quitarVida(5, "5");
        }
        else
        {
            golpeado = true;
        }

    }
}
