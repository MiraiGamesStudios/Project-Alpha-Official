using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private bool golpeado = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision?.transform.root.gameObject.tag == "Enemigo" && golpeado == false)
        {
            golpeado = true;
            collision.transform.root.gameObject.GetComponent<Caballero>().quitarVida(5, "5");
        }
    }
}
