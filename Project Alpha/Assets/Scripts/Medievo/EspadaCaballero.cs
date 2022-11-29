using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaCaballero : MonoBehaviour
{
    public delegate void _dañarPersonaje(int daño);
    public static event _dañarPersonaje dañarPersonajeC;

    public GameObject caballero;

    private void OnTriggerEnter(Collider other)
    {
        if (other?.gameObject.tag == "Player" && caballero.GetComponent<Caballero>().puedoDañar == true)
        {
            dañarPersonajeC(10);
        }
    }
}
