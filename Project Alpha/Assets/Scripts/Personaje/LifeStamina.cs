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

    public float cantidadVida;

    public bool outStamina = false;
    public bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        lifeSlide.value = vidaMaxima;
        staminaSlide.value = staminaMaxima;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            StartCoroutine(lifeLost(cantidadVida)); 
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
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

            if(lifeSlide.value == 0)
            {
                death = true;
            }

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

        if (staminaSlide.value == 0)
        {
            outStamina = true;
        }
        yield return null;

        
    }

    IEnumerator staminaRecover()
    {

        while (outStamina == true)
        {
            yield return new WaitForSeconds(4);
            outStamina = false;
        }

        float i = 0.005f;
        staminaSlide.value += i;    

        yield return null;


    }
}
