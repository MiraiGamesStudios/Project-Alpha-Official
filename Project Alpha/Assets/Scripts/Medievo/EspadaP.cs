using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaP : MonoBehaviour
{
    public GameObject targetE;

    private void OnTriggerEnter(Collider other)
    {
        if (other?.transform.root.gameObject.tag == "Mago"
            || other?.transform.root.gameObject.tag == "Arquero"
            || other?.transform.root.gameObject.tag == "Caballero"
            || other?.transform.root.gameObject.tag == "Escudero")
        {
            
            targetE = other.transform.root.gameObject;

        }
    }
}
