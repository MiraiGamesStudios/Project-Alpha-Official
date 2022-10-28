using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porra : MonoBehaviour
{
    public GameObject targetP;
    public GameObject noTarget;
    public string tipoArma;

    private void OnCollisionExit(Collision collision)
    {
        targetP = noTarget;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponentInParent<Dinosaur>().gameObject.tag == "Dinosaur")
        {
            targetP = collider.GetComponentInParent<Dinosaur>().gameObject;
        }
    }
}
