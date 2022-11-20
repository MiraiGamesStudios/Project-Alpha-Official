using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaP : MonoBehaviour
{
    public GameObject targetE;

    private void OnTriggerEnter(Collider other)
    {

        print(other.gameObject);

        if (other?.gameObject.GetComponentInParent<Mago>()?.gameObject.tag == "Mago")
        {
            targetE = other.GetComponentInParent<Mago>().gameObject;
        }
        if (other?.gameObject.GetComponentInParent<Arquero>()?.gameObject.tag == "Arquero")
        {
            targetE = other.GetComponentInParent<Arquero>().gameObject;
        }
        if (other?.gameObject.GetComponentInParent<Escudero>()?.gameObject.tag == "Escudero")
        {
            targetE = other.GetComponentInParent<Escudero>().gameObject;
        }
        if (other?.gameObject.GetComponentInParent<Caballero>()?.gameObject.tag == "Caballero")
        {
            targetE = other.GetComponentInParent<Caballero>().gameObject;
        }
    }
}
