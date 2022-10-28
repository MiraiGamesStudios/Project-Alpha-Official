using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event_pegar : MonoBehaviour
{
    public Lanza lanza;
    public Porra porra;
    public Antorcha antorcha;

    public Player player;

    public GameObject damageText;
    public GameObject posDaño;


    public void GolpePorra()
    {
        if (porra.targetP.tag == "Dinosaur")
        {
            QuitarVida(porra.targetP);
            porra.targetP = porra.noTarget;
        }
        
    }
    public void GolpeLanza()
    {
        //print(lanza.targetL);
        if (lanza.targetL.tag == "Dinosaur")
        {
            QuitarVida(lanza.targetL);
            lanza.targetL = lanza.noTarget;
        }

    }
    public void GolpeAntorcha()
    {
        if (antorcha.targetA.tag == "Dinosaur")
        {
            
            QuitarVida(antorcha.targetA);
            antorcha.targetA = antorcha.noTarget;
        }

    }

    void QuitarVida(GameObject target)
    {
        target.GetComponent<Dinosaur>().life -= 10;
        numerosPantalla(10, "10");
    }

    IEnumerator quemarse(GameObject target)
    {

        if (!target.GetComponent<Dinosaur>().quemandome)
        {
            target.GetComponent<Dinosaur>().quemandome = true;
            target.GetComponent<Dinosaur>().quemadura.SetActive(true);

            for (int i = 0; i < 10; i++)
            {
                if (target.GetComponent<Dinosaur>().muerto == true)
                {
                    yield return null;
                }

                target.GetComponent<Dinosaur>().life--;

                numerosPantalla(3, "1");

                yield return new WaitForSeconds(1f);
            }

            target.GetComponent<Dinosaur>().quemadura.SetActive(false);
            target.GetComponent<Dinosaur>().quemandome = false;

        }

        yield return null;
    }

    void numerosPantalla(float tamaño, string daño)
    {
        Vector3 posicion = new Vector3(this.transform.position.x + 0.5f + Random.Range(-0.3f, 0.3f), this.transform.position.y + 2.8f + Random.Range(0f, 0.5f), this.transform.position.z + Random.Range(-0.5f, 0.5f));

        GameObject textGO = Instantiate(damageText, posicion, Quaternion.LookRotation(this.transform.forward));
        textGO.GetComponentInChildren<TextMeshPro>().SetText(daño);
        textGO.GetComponentInChildren<TextMeshPro>().fontSize = tamaño;
        Destroy(textGO, 1);
    }
}
