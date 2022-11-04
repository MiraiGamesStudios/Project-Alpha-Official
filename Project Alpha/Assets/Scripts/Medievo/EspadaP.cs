using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaP : MonoBehaviour
{
    public delegate void _dañarEnemigo(GameObject go);
    public static event _dañarEnemigo dañarEnemigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Enemigo")
        {
            dañarEnemigo(other.transform.root.gameObject);
        }
    }
}
