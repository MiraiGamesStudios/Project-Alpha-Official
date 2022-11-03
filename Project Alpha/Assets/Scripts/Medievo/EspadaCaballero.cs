using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaCaballero : MonoBehaviour
{
    public delegate void _dañarPersonaje(int daño);
    public static event _dañarPersonaje dañarPersonaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dañarPersonaje(10);
        }
    }
}
