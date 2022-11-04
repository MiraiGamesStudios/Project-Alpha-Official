using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaP : MonoBehaviour
{
    public delegate void _da�arEnemigo(GameObject go);
    public static event _da�arEnemigo da�arEnemigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Enemigo")
        {
            da�arEnemigo(other.transform.root.gameObject);
        }
    }
}
