using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoE : MonoBehaviour
{
    public delegate void _dañarPersonaje(int daño);
    public static event _dañarPersonaje dañarPersonajeE;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other?.gameObject.tag == "Player")
        {
            dañarPersonajeE(10);
        }
    }
}
