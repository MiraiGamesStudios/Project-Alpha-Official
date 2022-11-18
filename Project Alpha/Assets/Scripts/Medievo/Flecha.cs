using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private bool golpeado = false;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision?.transform.root.gameObject.tag == "Caballero" && golpeado == false)
        {
            print("HOLA");
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Caballero>().quitarVida(5, "5");
        }

        if (collision?.transform.root.gameObject.tag == "Arquero" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Arquero>().quitarVida(5, "5");
        }

        if (collision?.transform.root.gameObject.tag == "Escudero" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Escudero>().quitarVida(5, "5");
        }

        if (collision?.transform.root.gameObject.tag == "Mago" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Mago>().quitarVida(5, "5");
        }
        else
        {
            golpeado = true;
        }

    }
}
