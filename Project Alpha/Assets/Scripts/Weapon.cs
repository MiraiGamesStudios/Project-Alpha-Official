using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public bool dañar = false;
    public Dinosaur target;


    public void Update()
    {
        dañar = false;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Dinosaur")
        {
            dañar = false;
            target = null;
        }
    }

    //Necesita isTrigger del box collider del arma a True y is kinematic a True
    public void OnTriggerEnter(Collider collider)
    {
        //GameObject objeto1 = GameObject.Find("objeto1");
        if (collider.gameObject.tag == "Dinosaur")
        {
            dañar = true;
            target = collider.gameObject;
        }

    }

    public void HacerDaño()
    {
        if (dañar)
        {
            print("aaaaaaaa");
        }
    }
}
