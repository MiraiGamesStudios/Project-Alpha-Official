using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicoS : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other?.gameObject.tag == "Player")
        {
            target = other.gameObject;
        }
    }
}
