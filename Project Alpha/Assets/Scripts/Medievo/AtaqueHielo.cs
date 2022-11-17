using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueHielo : MonoBehaviour
{
    public delegate void _AHielo(int daño);
    public static _AHielo AHielo;

    public int daño;

    private void OnCollisionEnter(Collision other)
    {
        if (other?.gameObject.tag == "Player")
        {
            AHielo(daño);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
