using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaEnemigos : MonoBehaviour
{
    private bool golpeado = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && golpeado == false)
        {
            golpeado = true;
            collision.gameObject.GetComponent<LifeStamina>().comenzarCorrutinaVida(10);
        }
        this.gameObject.SetActive(false);

    }
}
