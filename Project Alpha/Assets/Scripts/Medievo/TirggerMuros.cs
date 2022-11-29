using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirggerMuros : MonoBehaviour
{
    public delegate void _TriggerMurosDentro();
    public static _TriggerMurosDentro TriggerMurosDentro;

    public delegate void _TriggerMurosExit();
    public static _TriggerMurosExit TriggerMurosExit;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        TriggerMuros();
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerMurosDentro();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerMurosExit();
        }
    }
}
