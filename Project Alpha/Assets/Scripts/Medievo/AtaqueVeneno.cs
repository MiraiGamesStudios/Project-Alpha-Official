using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueVeneno : MonoBehaviour
{
    public delegate void _AVeneno(int da�o);
    public static _AVeneno AVeneno;

    public int da�o;

    private void OnCollisionEnter(Collision other)
    {
        if (other?.gameObject.tag == "Player")
        {
            AVeneno(da�o);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
