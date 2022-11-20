using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public List<GameObject> enemigosDentro;

    private void OnTriggerEnter(Collider other)
    {
        if (other?.gameObject.GetComponentInParent<Worker>()?.gameObject.tag == "Worker")
        {
            other?.gameObject.GetComponentInParent<Worker>().quitarVida(20, "20");
            other.gameObject.GetComponentInParent<Worker>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
        if (other?.gameObject.GetComponentInParent<Suit>()?.gameObject.tag == "Suit")
        {
            other?.gameObject.GetComponentInParent<Suit>().quitarVida(20, "20");
            other.gameObject.GetComponentInParent<Suit>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
        if (other?.gameObject.GetComponentInParent<Militar>()?.gameObject.tag == "Militar")
        {
            other?.gameObject.GetComponentInParent<Militar>().quitarVida(20, "20");
            other.gameObject.GetComponentInParent<Militar>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
        if (other?.gameObject.GetComponentInParent<Police>()?.gameObject.tag == "Policia")
        {
            other?.gameObject.GetComponentInParent<Police>().quitarVida(20, "20");
            other.gameObject.GetComponentInParent<Police>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
        if (other?.gameObject.GetComponentInParent<Militar>()?.gameObject.tag == "Boss")
        {
            other?.gameObject.GetComponentInParent<Militar>().quitarVida(20, "20");
            other.gameObject.GetComponentInParent<Militar>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
    }

    public void hacerGrande()
    {
        this.GetComponent<SphereCollider>().radius = 0.05f;
    }

    IEnumerator destruir()
    {
        this.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
    }
}
