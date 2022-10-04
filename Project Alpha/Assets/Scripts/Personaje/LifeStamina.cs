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

        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(lifeLost(cantidadVida)); 
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            StartCoroutine(staminaLost());
        }
        else
        {
            StartCoroutine(staminaRecover());
        }

    }

    IEnumerator lifeLost(float vida)
    {
        float cantidadPerdida = 0;
        float i = 0.2f;

        while (cantidadPerdida <= vida)
        {

            lifeSlide.value -= i;
            cantidadPerdida += i;
            i+=0.01f;

            yield return new WaitForSeconds(0.01f);
        }

        
        yield return null;

    }

    IEnumerator staminaLost()
    {

        float i = 0.01f;
        staminaSlide.value -= i;

        yield return null;

        
    }

    IEnumerator staminaRecover()
    {

        

        float i = 0.005f;
        staminaSlide.value += i;

        yield return null;


    }
}
