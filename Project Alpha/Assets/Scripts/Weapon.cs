using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public bool da�ar = false;
    public Dinosaur target;


    public void Update()
    {
        da�ar = false;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Dinosaur")
        {
            da�ar = false;
            target = null;
        }
    }

    //Necesita isTrigger del box collider del arma a True y is kinematic a True
    public void OnTriggerEnter(Collider collider)
    {
        //GameObject objeto1 = GameObject.Find("objeto1");
        if (collider.gameObject.tag == "Dinosaur")
        {
            da�ar = true;
            target = collider.gameObject;
        }

    }

    public void HacerDa�o()
    {
        if (da�ar)
        {
            print("aaaaaaaa");
        }
    }
}
