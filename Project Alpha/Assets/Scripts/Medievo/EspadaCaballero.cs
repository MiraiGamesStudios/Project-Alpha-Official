using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaCaballero : MonoBehaviour
{
    public delegate void _daņarPersonaje(int daņo);
    public static event _daņarPersonaje daņarPersonaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            daņarPersonaje(10);
        }
    }
}
