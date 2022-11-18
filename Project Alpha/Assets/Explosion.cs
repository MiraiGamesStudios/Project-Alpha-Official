using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public List<GameObject> enemigosDentro;

    private void OnCollisionStay(Collision other)
    {
        if (other?.transform.root.gameObject.tag == "Policia")
        {
            other?.transform.root.gameObject.GetComponent<Police>().quitarVida(20, "20");
        }
        if (other?.transform.root.gameObject.tag == "Militar")
        {
            other?.transform.root.gameObject.GetComponent<Militar>().quitarVida(20, "20");
        }
        if (other?.transform.root.gameObject.tag == "Worker")
        {
            other?.transform.root.gameObject.GetComponent<Worker>().quitarVida(20, "20");
        }
        if (other?.transform.root.gameObject.tag == "Suit")
        {
            other?.transform.root.gameObject.GetComponent<Suit>().quitarVida(20, "20");
        }
    }

    //public void hacerDaño(int daño)
    //{
    //    int i = 0;
    //    while(enemigosDentro.Count != 0)
    //    {
    //        if(enemigosDentro[i].tag == "Policia")
    //        {
    //            enemigosDentro[i].GetComponent<Police>().quitarVida(daño, "20");
    //            enemigosDentro.Remove(enemigosDentro[i]);
    //        }
    //        if (enemigosDentro[i].tag == "Militar")
    //        {
    //            enemigosDentro[i].GetComponent<Militar>().quitarVida(daño, "20");
    //            enemigosDentro.Remove(enemigosDentro[i]);
    //        }
    //        if (enemigosDentro[i].tag == "Suit")
    //        {
    //            enemigosDentro[i].GetComponent<Suit>().quitarVida(daño, "20");
    //            enemigosDentro.Remove(enemigosDentro[i]);
    //        }
    //        if (enemigosDentro[i].tag == "Worker")
    //        {
    //            enemigosDentro[i].GetComponent<Worker>().quitarVida(daño, "20");
    //            enemigosDentro.Remove(enemigosDentro[i]);
    //        }

    //        i++;
    //    }
    //}
}
