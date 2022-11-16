using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeStamina : MonoBehaviour
{
    #region Variables
    public Slider lifeSlide;
    public Slider staminaSlide;

    public TMP_Text lifeNumber;
    public TMP_Text staminaNumber;

    public RawImage sangrePantalla;

    public float vidaMaxima;
    public float cantidadVida;
    public float staminaMaxima;

    public int segRec;
    private int segundosParaRecuperar;

    public bool recuperando = false;
    public bool outStamina = false;
    public bool death = false;

    public List<GameObject> Lactiva;
    public List<GameObject> Lderecha;
    public List<GameObject> Lizquierda;

    public bool da�o = false;

    public GameObject fuego;
    public GameObject veneno;

    #endregion

    #region Metodos Unity
    // Start is called before the first frame update
    void Start()
    {
        lifeSlide.maxValue = vidaMaxima;
        lifeSlide.value = vidaMaxima;

        staminaSlide.maxValue = staminaMaxima;
        staminaSlide.value = staminaMaxima;

        segundosParaRecuperar = segRec;
    }


    void Update()
    {
        if (lifeSlide.value != vidaMaxima && recuperando == false && da�o == false)
        {
            recuperando = true;
            StartCoroutine(waiting(segundosParaRecuperar));
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
    private void OnEnable()
    {
        Dinosaur.da�oRecibido += mostrarDa�o;

        EspadaCaballero.da�arPersonajeC += comenzarCorrutinaVida;
        EscudoE.da�arPersonajeE += comenzarCorrutinaVida; 
        AtaqueElectrico.AElectricoDa�o += comenzarCorrutinaVida;
        AtaqueFuego.AFuego += comenzarCorrutinaVida;
        AtaqueFuego.AFuego += comenzarCorrutinaFuego;
        AtaqueVeneno.AVeneno += comenzarCorrutinaVida;
        AtaqueVeneno.AVeneno += comenzarCorrutinaenvenenado;
        AtaqueHielo.AHielo += comenzarCorrutinaVida;

        Worker.da�arPersonajeMartillo += comenzarCorrutinaVida;
        Suit.da�arPersonajePeriodico += comenzarCorrutinaVida;

    }
    private void OnDisable()
    {
        Dinosaur.da�oRecibido -= mostrarDa�o;

        EspadaCaballero.da�arPersonajeC -= comenzarCorrutinaVida;
        EscudoE.da�arPersonajeE -= comenzarCorrutinaVida;
        AtaqueElectrico.AElectricoDa�o -= comenzarCorrutinaVida;
        AtaqueFuego.AFuego -= comenzarCorrutinaVida;
        AtaqueFuego.AFuego -= comenzarCorrutinaFuego;
        AtaqueVeneno.AVeneno -= comenzarCorrutinaVida;
        AtaqueVeneno.AVeneno += comenzarCorrutinaenvenenado;
        AtaqueHielo.AHielo += comenzarCorrutinaVida;

        Worker.da�arPersonajeMartillo -= comenzarCorrutinaVida;
        Suit.da�arPersonajePeriodico -= comenzarCorrutinaVida;

    }
    #endregion

    #region FeedBack Da�o
    void mostrarDa�o()
    { 
        sangrePantalla.color = new Color(255,255,255,0.75f);
        StartCoroutine(espera());
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.5f);

        sangrePantalla.color = new Color(255, 255, 255, 0);

        yield return null;

    }

    #endregion

    #region Metodos Stamina
    IEnumerator staminaLost()
    {

        float i = 0.01f;
        staminaSlide.value -= i;
        staminaNumber.SetText(staminaSlide.value.ToString("#."));

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
        staminaNumber.SetText(staminaSlide.value.ToString("#."));

        yield return null;

    }
    #endregion

    #region Metodos Vida

    public void comenzarCorrutinaVida(int da�o)
    {
        StartCoroutine(lifeLost(da�o));
    }
    public void comenzarCorrutinaFuego(int a)
    {
        StartCoroutine(Quemarse());
    }

    void comenzarCorrutinaenvenenado(int a)
    {
        StartCoroutine(envenenado());
    }
    public IEnumerator lifeLost(float vida)
    {
        //StopCoroutine(recoverLife(segundosParaRecuperar));
        da�o = true;

        float cantidadPerdida = 0;
        float i = 0.2f;

        while (cantidadPerdida <= vida)
        {

            lifeSlide.value -= i;
            lifeNumber.SetText(lifeSlide.value.ToString("#."));

            if (lifeSlide.value == 0)
            {
                death = true;
            }

            cantidadPerdida += i;
            i += 0.01f;

            yield return new WaitForSeconds(0.01f);
        }

        da�o = false;

        yield return null;
    }

    IEnumerator waiting(int seg)
    {
        bool meHanDado = false;
        for (int j = 0; j < seg; j++)
        {
            yield return new WaitForSeconds(1);
            
            if (da�o)
            {
                meHanDado = true;
                break;
            }
        }

        if(meHanDado == false)
        {
            StartCoroutine(recoverLife(seg));
            yield return null;
        }
        else
        {
            recuperando = false;
        }

    }
    public IEnumerator recoverLife(int seg)
    {
        //for (int j = 0; j < seg; j++)
        //{
        //    yield return new WaitForSeconds(1);
        //    if (da�o)
        //    {
        //        break;
        //    }
        //}
        float i = 0.05f;

        while (lifeSlide.value != vidaMaxima)
        {
            
            if (da�o)
            {
                break;
            }

            lifeSlide.value += i;
            lifeNumber.SetText(lifeSlide.value.ToString("#."));
            yield return new WaitForSeconds(0.01f);

        }


        recuperando = false;
        yield return null;

    }

    IEnumerator Quemarse()
    {

        if (fuego.active == false)
        {
            fuego.SetActive(true);
            
            for (int i = 0; i < 10; i++)
            {
                //StopCoroutine(recoverLife(segundosParaRecuperar));
                da�o = true;

                if (death == true)
                {
                    yield return null;
                }

                lifeSlide.value--;
                lifeNumber.SetText(lifeSlide.value.ToString("#."));

                yield return new WaitForSeconds(1f);
            }

            da�o = false;
            fuego.SetActive(false);

        }

        yield return null;
    }

    IEnumerator envenenado()
    {
        veneno.SetActive(true);
        da�o = true;
        segundosParaRecuperar = segRec * 2;
        lifeSlide.GetComponentInChildren<Image>().color = new Color(0, 0.3f, 0, 1);

        yield return new WaitForSeconds(10);

        veneno.SetActive(false);
        da�o = false;
        segundosParaRecuperar = segRec;
        lifeSlide.GetComponentInChildren<Image>().color = new Color(255, 0, 0, 255);
    }

    #endregion
}
