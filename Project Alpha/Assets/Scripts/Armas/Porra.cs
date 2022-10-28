using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porra : MonoBehaviour
{
    public GameObject target;
    public GameObject noTarget;
    public string tipoArma;

    public void OnTriggerEnter(Collider collider)
    {
        print(collider.GetComponentInParent<Dinosaur>().gameObject);
        if (collider.GetComponentInParent<Dinosaur>().gameObject.tag == "Dinosaur")
        {
            target = collider.GetComponentInParent<Dinosaur>().gameObject;
        }
    }
}
