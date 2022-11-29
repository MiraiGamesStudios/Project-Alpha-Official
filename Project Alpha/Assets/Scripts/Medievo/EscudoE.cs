using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoE : MonoBehaviour
{
    public delegate void _da�arPersonaje(int da�o);
    public static event _da�arPersonaje da�arPersonajeE;

    public GameObject escudero;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other?.gameObject.tag == "Player" && escudero.GetComponent<Escudero>().puedoDa�ar == true)
        {
            da�arPersonajeE(10);
        }
    }
}
