using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueFuego : MonoBehaviour
{
    public delegate void _AFuego(int da�o);
    public static _AFuego AFuego;

    public int da�o;

    private void OnCollisionEnter(Collision other)
    {
        if (other?.gameObject.tag == "Player")
        {
            AFuego(da�o);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
