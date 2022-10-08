using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Necesita isTrigger del box collider del arma a False y is kinematic a false
    //Pero is le quitas esto el personaje se vuelve loco
    void OnCollisionEnter(Collision collision)
    {
        //GameObject objeto1 = GameObject.Find("Apatosaurus");
        if (collision.gameObject.tag == "Dinosaur")
        {
            Debug.Log("CLUB ha colisionado con el dinosaurio");
            
        }
    }

    //Necesita isTrigger del box collider del arma a True y is kinematic a True
    void OnTriggerEnter(Collider collider)
    {
        //GameObject objeto1 = GameObject.Find("objeto1");
        if (collider.gameObject.tag == "Dinosaur")
        {
            Debug.Log("CLUB ha entrado en área del dinosaurio");
        }
    }
}
