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
        if(espada.targetE.tag == "Caballero")
        {
            print(espada.targetE);
            espada.targetE.GetComponent<Caballero>().quitarVida(10, "10");
        }
        if (espada.targetE.tag == "Arquero")
        {
            espada.targetE.GetComponent<Arquero>().quitarVida(10, "10");
        }
        if (espada.targetE.tag == "Escudero")
        {
            espada.targetE.GetComponent<Escudero>().quitarVida(10, "10");
        }
        if (espada.targetE.tag == "Mago")
        {
            espada.targetE.GetComponent<Mago>().quitarVida(10, "10");
        }
    }

    void resetTarget()
    {
        espada.targetE = null;
    }
}
