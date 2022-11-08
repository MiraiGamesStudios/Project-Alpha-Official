using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoE : MonoBehaviour
{
    public delegate void _daņarPersonaje(int daņo);
    public static event _daņarPersonaje daņarPersonajeE;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other?.gameObject.tag == "Player")
        {
            print("HOLA");
            daņarPersonajeE(10);
        }
    }
}
