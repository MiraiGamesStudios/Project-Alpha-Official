using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirggerMuros : MonoBehaviour
{
    public delegate void _TriggerMuros();
    public static _TriggerMuros TriggerMuros;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerMuros();
        }
    }
}
