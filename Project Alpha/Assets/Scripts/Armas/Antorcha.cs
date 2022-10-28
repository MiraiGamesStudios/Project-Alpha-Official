using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorcha : MonoBehaviour
{
    
    public GameObject targetA;
    public GameObject noTarget;
    public string tipoArma;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponentInParent<Dinosaur>().gameObject.tag == "Dinosaur")
        {
            targetA = collider.GetComponentInParent<Dinosaur>().gameObject;
        }
    }
}
