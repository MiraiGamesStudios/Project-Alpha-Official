using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LifeStamina : MonoBehaviour
{

    public int stamina;
    public int life;

    public GameObject lifeBar;
    public GameObject staminaBar;

    public Slider lifeSlide;
    public Slider staminaSlide;


    public bool perderVida;
    public float cantidadVida;

    // Start is called before the first frame update
    void Start()
    {
        lifeSlide = lifeBar.GetComponent<Slider>();
        staminaSlide = staminaBar.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (perderVida)
        {
            lifeLost(cantidadVida);
        }
    }

    void lifeLost(float vida)
    {

        lifeSlide.value -= vida;
        perderVida = false;

    }
}
