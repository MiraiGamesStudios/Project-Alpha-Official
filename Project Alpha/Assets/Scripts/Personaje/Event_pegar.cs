using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_pegar : MonoBehaviour
{
    public Weapon arma;
    public List<GameObject> dinos;

    public bool guardarDinos = false;
    int i = 0;

    private void Update()
    {
        if (guardarDinos) a�adirDinos();
    }

    public void InicioPegar()
    {
        guardarDinos = true;
        //if (arma.da�ar)
        //{
        //    //arma.target.

        //    // si es antorcha StartCoroutine(quemarse());
        //}
    }

    public void FinPegar()
    {
        guardarDinos = false;
    }

    void a�adirDinos()
    {
        if(arma.target.tag == "Dinosaur")
        {
            if (dinos.Count == 0)
            {
                dinos.Add(arma.target);

            }
            else if(arma.target != dinos[dinos.Count - 1])
            {
                dinos.Add(arma.target);
            }

        }
        
    }

}
