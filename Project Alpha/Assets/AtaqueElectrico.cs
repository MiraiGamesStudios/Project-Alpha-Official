using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueElectrico : MonoBehaviour
{
    public delegate void _AElectricoDaño(int daño);
    public static _AElectricoDaño AElectricoDaño;

    public delegate void _AElectricoStun(int segQuieto);
    public static _AElectricoStun AElectricoStun;

    public int daño;
    public int stun;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AElectricoDaño(daño);
            AElectricoStun(stun);
        }
    }
}
