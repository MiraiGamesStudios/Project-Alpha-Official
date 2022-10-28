using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanza : MonoBehaviour
{
    
    public GameObject targetL;
    public GameObject noTarget;
    public string tipoArma;

    public void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject);
        if (collider.GetComponentInParent<Dinosaur>().gameObject.tag == "Dinosaur")
        {
            targetL = collider.GetComponentInParent<Dinosaur>().gameObject;
        }
    }
}
