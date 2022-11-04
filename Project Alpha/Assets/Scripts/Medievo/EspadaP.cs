using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaP : MonoBehaviour
{
    public GameObject targetE;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Enemigo")
        {
            
            targetE = other.transform.root.gameObject;

        }
    }
}
