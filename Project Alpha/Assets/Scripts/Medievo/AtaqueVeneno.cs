using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueVeneno : MonoBehaviour
{
    public delegate void _AVeneno(int daño);
    public static _AVeneno AVeneno;

    public int daño;

    private void OnCollisionEnter(Collision other)
    {
        if (other?.gameObject.tag == "Player")
        {
            AVeneno(daño);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
