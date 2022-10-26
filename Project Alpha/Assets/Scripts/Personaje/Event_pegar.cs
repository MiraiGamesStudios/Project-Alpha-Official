using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event_pegar : MonoBehaviour
{
    public Weapon arma;
    public List<GameObject> dinos;

    public GameObject damageText;
    public GameObject posDaño;

    bool guardarDinos = false;
    //int i = 0;

    private void Update()
    {
        if (guardarDinos) añadirDinos();
    }

    public void InicioPegar()
    {
        guardarDinos = true;
    }

    public void FinPegar()
    {
        guardarDinos = false;
    }

    void añadirDinos()
    {

        if (arma.target.tag == "Dinosaur")
        {

            if (dinos.Count == 0)
            {
                dinos.Add(arma.target);

            }
            else if (arma.target != dinos[dinos.Count - 1])
            {
                dinos.Add(arma.target);
            }

            for (int i = 0; i < dinos.Count; i++)
            {
                if (dinos[i].GetComponent<Dinosaur>().muerto)
                {
                    break;
                }
                StartCoroutine(QuitarVidaDino(dinos[i]));

                if (arma.tipoArma == "Antorcha")
                {
                    StartCoroutine(quemarse(dinos[i]));
                }
            }

            dinos.Clear();

        }
    }

    IEnumerator QuitarVidaDino(GameObject target)
    {

        if (target.GetComponent<Dinosaur>().dañandome == false)
        {
            target.GetComponent<Dinosaur>().dañandome = true;

            target.GetComponent<Dinosaur>().life -= 10;
            numerosPantalla(10, "10");

            yield return new WaitForSeconds(0.2f);

            target.GetComponent<Dinosaur>().dañandome = false;
        }

        yield return null;
    }

    IEnumerator quemarse(GameObject target)
    {

        if (!target.GetComponent<Dinosaur>().quemandome)
        {
            target.GetComponent<Dinosaur>().quemadura.SetActive(true);
            target.GetComponent<Dinosaur>().quemandome = true;

            for (int i = 0; i < 10; i++)
            {
                if(target.GetComponent<Dinosaur>().muerto == true)
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
