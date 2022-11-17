using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueHielo : MonoBehaviour
{
    public delegate void _AHielo(int da�o);
    public static _AHielo AHielo;

    public int da�o;

    private void OnCollisionEnter(Collision other)
    {
        if (other?.gameObject.tag == "Player")
        {
            AHielo(da�o);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
