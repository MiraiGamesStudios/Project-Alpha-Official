using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porra : MonoBehaviour
{
    public GameObject targetP;
    public GameObject noTarget;
    public string tipoArma;
    public bool espera = false;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponentInParent<Dinosaur>().gameObject.tag == "Dinosaur" && !espera)
        {
            targetP = collider.GetComponentInParent<Dinosaur>().gameObject;
        }
    }
}
