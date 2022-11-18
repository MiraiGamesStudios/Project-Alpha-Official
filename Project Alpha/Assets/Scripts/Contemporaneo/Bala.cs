using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private bool golpeado = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision?.transform.root.gameObject.tag == "Policia" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Police>().quitarVida(5, "5");
            Destroy(gameObject);
        }

        if (collision?.transform.root.gameObject.tag == "Militar" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Militar>().quitarVida(5, "5");
            Destroy(gameObject);
        }

        if (collision?.transform.root.gameObject.tag == "Worker" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Worker>().quitarVida(5, "5");
            Destroy(gameObject);
        }

        if (collision?.transform.root.gameObject.tag == "Suit" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Suit>().quitarVida(5, "5");
            Destroy(gameObject);
        }
        else
        {
            golpeado = true;
        }

    }
}
