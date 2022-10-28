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

    public List<GameObject> Lactiva;
    public List<GameObject> Lderecha;
    public List<GameObject> Lizquierda;


    // Start is called before the first frame update
    void Start()
    {
        lifeSlide.maxValue = vidaMaxima;
        lifeSlide.value = vidaMaxima;

        staminaSlide.maxValue = staminaMaxima;
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

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Lactiva[0].SetActive(true);
            Lactiva[1].SetActive(false);
            Lactiva[2].SetActive(false);

            Lderecha[0].SetActive(false);
            Lderecha[1].SetActive(true);
            Lderecha[2].SetActive(false);

            Lizquierda[0].SetActive(false);
            Lizquierda[1].SetActive(false);
            Lizquierda[2].SetActive(true);


        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Lactiva[0].SetActive(false);
            Lactiva[1].SetActive(true);
            Lactiva[2].SetActive(false);

            Lderecha[0].SetActive(false);
            Lderecha[1].SetActive(false);
            Lderecha[2].SetActive(true);

            Lizquierda[0].SetActive(true);
            Lizquierda[1].SetActive(false);
            Lizquierda[2].SetActive(false);

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Lactiva[0].SetActive(false);
            Lactiva[1].SetActive(false);
            Lactiva[2].SetActive(true);

            Lderecha[0].SetActive(true);
            Lderecha[1].SetActive(false);
            Lderecha[2].SetActive(false);

            Lizquierda[0].SetActive(false);
            Lizquierda[1].SetActive(true);
            Lizquierda[2].SetActive(false);
        }

    }

    public IEnumerator lifeLost(float vida)
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
