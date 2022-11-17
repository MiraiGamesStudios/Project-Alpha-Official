using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueFuego : MonoBehaviour
{
    public delegate void _AFuego(int daño);
    public static _AFuego AFuego;

    public int daño;

    private void OnCollisionEnter(Collision other)
    {
        if (other?.gameObject.tag == "Player")
        {
            AFuego(daño);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
