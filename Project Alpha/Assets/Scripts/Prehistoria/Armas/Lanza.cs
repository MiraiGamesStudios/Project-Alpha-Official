using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanza : MonoBehaviour
{
    
    public GameObject targetL;
    public GameObject noTarget;
    public string tipoArma;

    private void OnCollisionExit(Collision collision)
    {
        targetL = noTarget;
    }
    public void OnTriggerEnter(Collider collider)
    {
        
        if (collider.GetComponentInParent<Dinosaur>().gameObject.tag == "Dinosaur")
        {
            targetL = collider.GetComponentInParent<Dinosaur>().gameObject;
        }
    }
}
