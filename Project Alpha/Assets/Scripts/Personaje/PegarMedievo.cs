using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarMedievo : MonoBehaviour
{

    #region Variables

    public EspadaP espada;

    #endregion

    void GolpeEspada()
    {
        if(espada.targetE?.tag == "Enemigo")
        {
            espada.targetE.GetComponent<Caballero>().quitarVida(10, "10");
        }
    }

    void resetTarget()
    {
        espada.targetE = null;
    }
}
