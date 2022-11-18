using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public List<GameObject> enemigosDentro;

    private void OnTriggerEnter(Collider other)
    {
        if (other?.transform.root.gameObject.tag == "Policia")
        {
            other?.transform.root.gameObject.GetComponent<Police>().quitarVida(20, "20");
            other.transform.root.gameObject.GetComponent<Police>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
        if (other?.transform.root.gameObject.tag == "Militar")
        {
            other?.transform.root.gameObject.GetComponent<Militar>().quitarVida(20, "20");
            other.transform.root.gameObject.GetComponent<Militar>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
        if (other?.transform.root.gameObject.tag == "Worker")
        {
            other?.transform.root.gameObject.GetComponent<Worker>().quitarVida(20, "20");
            other.transform.root.gameObject.GetComponent<Worker>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
        if (other?.transform.root.gameObject.tag == "Suit")
        {
            other?.transform.root.gameObject.GetComponent<Suit>().quitarVida(20, "20");
            other.transform.root.gameObject.GetComponent<Suit>().golpeadoExplosion = true;
            StartCoroutine(destruir());
        }
    }

    public void hacerGrande()
    {
        this.GetComponent<SphereCollider>().radius = 0.05f;
    }

    IEnumerator destruir()
    {

        yield return new WaitForSeconds(0.5f);
    }
}
