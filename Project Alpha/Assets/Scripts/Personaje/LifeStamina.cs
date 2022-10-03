using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeStamina : MonoBehaviour
{

    public Slider lifeSlide;
    public Slider staminaSlide;

    public float vidaMaxima;
    public float staminaMaxima;

    public bool perderVida;
    public float cantidadVida;

    public bool perderStamina;
    public float cantidadStamina;

    // Start is called before the first frame update
    void Start()
    {
        lifeSlide.value = vidaMaxima;
        staminaSlide.value = staminaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        if (perderVida)
        {
            lifeLost(cantidadVida);
        }

        if (perderStamina)
        {
            staminaLost(cantidadStamina);
        }
    }

    void lifeLost(float vida)
    {
        /*float resta = 0;
        while (resta < vida / 2)
        {
            lifeSlide.value -= resta;
            resta += 0.01f;
        }

        while (resta <= vida)
        {
            lifeSlide.value -= resta;
            resta -= 0.01f;
        }*/

        /*float cantidadPerdida = 0;
       
        while (cantidadPerdida <= vida)
        {
            float i = 0;

            lifeSlide.value -= i;

            cantidadPerdida += i;

            i++;
        }*/

        lifeSlide.value -= vida;

        perderVida = false;

    }

    void staminaLost(float stamina)
    {
        /*float resta = 0;
        while (resta < vida / 2)
        {
            lifeSlide.value -= resta;
            resta += 0.01f;
        }

        while (resta <= vida)
        {
            lifeSlide.value -= resta;
            resta -= 0.01f;
        }*/
        staminaSlide.value -= stamina;

        perderStamina = false;

    }
}
