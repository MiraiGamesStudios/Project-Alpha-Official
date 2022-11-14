using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueElectrico : MonoBehaviour
{
    public delegate void _AElectricoDa�o(int da�o);
    public static _AElectricoDa�o AElectricoDa�o;

    public delegate void _AElectricoStun(int segQuieto);
    public static _AElectricoStun AElectricoStun;

    public int da�o;
    public int stun;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AElectricoDa�o(da�o);
            AElectricoStun(stun);
        }
    }
}
