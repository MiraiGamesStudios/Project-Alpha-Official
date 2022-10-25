using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_pegar : MonoBehaviour
{
    public Weapon arma;
    public List<Dinosaur> dinos;

    public bool guardarDinos = false;

    private void Update()
    {
        while (guardarDinos)
        {
            dinos.Add();
        }
    }

    public void InicoPegar()
    {

        guardarDinos = true;
        //if (arma.dañar)
        //{
        //    //arma.target.

        //    // si es antorcha StartCoroutine(quemarse());
        //}
    }

    public void FinPegar()
    {
        guardarDinos = false;
    }
}
