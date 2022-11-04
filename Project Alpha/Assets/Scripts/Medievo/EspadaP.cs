using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaP : MonoBehaviour
{
    public delegate void _daņarEnemigo(GameObject go);
    public static event _daņarEnemigo daņarEnemigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Enemigo")
        {
            daņarEnemigo(other.transform.root.gameObject);
        }
    }
}
