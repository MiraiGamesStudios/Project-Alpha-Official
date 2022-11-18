using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigos : MonoBehaviour
{
    private bool golpeado = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponent<LifeStamina>().comenzarCorrutinaVida(10);
        }

    }
}
