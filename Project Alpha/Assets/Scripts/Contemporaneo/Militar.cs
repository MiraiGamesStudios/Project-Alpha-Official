using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Militar : MonoBehaviour
{
    #region Variable

    public float speed = 4;
    public float life;
    bool restado = true;

    public GameManagerContemporaneo gm;
    Rigidbody rb;
    private Animator anim;

    public int area = 0;
    public GameObject damageText;


    GameObject player;

    private float avancePersonaje = 0.0f;
    [SerializeField] private float epsilonDistancia = 3f; // Distancia minima para alcanzar objetivo
    private float m_currentV = 0;                   // Posicion de avance actual 
    private readonly float m_interpolation = 10;    // Multiplicador para el paso de integracion
    [SerializeField] private float m_moveSpeed = 1;         // Velocidad de avance del personaje

    public enum Status { quieto, deambulando, corriendo, atacando, muerto };
    public Status statusMilitar = Status.quieto;

    public bool golpeadoExplosion = false;

    CharacterController ch;
    Vector3 localPosition;
    public float grav;

    bool bajarMuerte;


    #endregion

    #region Metodos Unity

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        player = GameObject.FindGameObjectWithTag("Player");
        ch = GetComponent<CharacterController>();
        ch.detectCollisions = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            statusMilitar = Status.muerto;
            if (restado)
            {
                restado = false;
                gm.enemigosVivos--;
            }

        }

        localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        if (statusMilitar == Status.corriendo)
        {
            ch.Move(new Vector3(localPosition.x, -grav, localPosition.z) * m_moveSpeed * Time.deltaTime);
            transform.LookAt(player.transform.position, Vector3.up);
        }

        FSMMilitar();
    }

    #endregion

    #region FSM
    public void FSMMilitar()
    {
        switch (statusMilitar)
        {
            case Status.quieto:
                //idle
                anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                if (Vector3.Distance(this.transform.position, player.transform.position) < 30)
                {
                    statusMilitar = Status.corriendo;
                }
                break;

            case Status.deambulando:
                //andar
                anim.SetFloat("Xaxis", 0.5f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                if (Vector3.Distance(this.transform.position, player.transform.position) < 30)
                {
                    statusMilitar = Status.corriendo;
                }
                break;

            case Status.corriendo:
                //correr
                Avanzar(player.transform.position);
                anim.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                if (this.EstaEnObjetivo(player.transform.position))
                {
                    statusMilitar = Status.atacando;
                }
                break;

            case Status.atacando:
                //atacar
                rb.isKinematic = true;
                Alinear(player.transform.position);
                anim.SetBool("Atacar", true);
                anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);

                if (!this.EstaEnObjetivo(player.transform.position))
                {
                    //rb.isKinematic = false;
                    statusMilitar = Status.corriendo;
                    anim.SetBool("Atacar", false);
                }
                break;

            case Status.muerto:
                //morir
                rb.isKinematic = false;
                anim.SetLayerWeight(1, 1);
                eliminarme();
                anim.SetBool("Morir", true);
                StartCoroutine(morir());
                Destroy(this.gameObject, 3.5f);
                avancePersonaje = 0.0f;
                break;
        }

    }

    void eliminarme()
    {
        if (area == 1)
        {
            //se elimina
            gm.GetComponent<GameManagerContemporaneo>().milArea1.Remove(this.gameObject);
        }
        else if (area == 2)
        {
            gm.GetComponent<GameManagerContemporaneo>().milArea2.Remove(this.gameObject);
        }

    }

    void Alinear(Vector3 _objetivo)
    {
        transform.LookAt(_objetivo);
    }
    public void Avanzar(Vector3 _objetivo)
    {
        Alinear(_objetivo);
        avancePersonaje = 1.0f;
    }
    public bool EstaEnObjetivo(Vector3 _objetivo)
    {
        return Vector3.Distance(transform.position, _objetivo) < epsilonDistancia;
    }
    #endregion

    #region Metodos Militar

    public void quitarVida(int daño, string numDaño)
    {
        if (!golpeadoExplosion && statusMilitar != Status.muerto)
        {
            life -= daño;
            numerosPantalla(daño, numDaño);
            StartCoroutine(resetearGolpeExplosion());
        }
    }

    void numerosPantalla(float tamaño, string daño)
    {
        Vector3 posicion = new Vector3(this.transform.position.x + 0.5f + Random.Range(-0.3f, 0.3f), this.transform.position.y + 2.8f + Random.Range(0f, 0.5f), this.transform.position.z + Random.Range(-0.5f, 0.5f));

        GameObject textGO = Instantiate(damageText, posicion, Quaternion.LookRotation(this.transform.forward));
        textGO.GetComponentInChildren<TextMeshPro>().SetText(daño);
        textGO.GetComponentInChildren<TextMeshPro>().fontSize = tamaño;
        Destroy(textGO, 1);
    }

    IEnumerator resetearGolpeExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        golpeadoExplosion = false;
    }
    IEnumerator morir()
    {
        if (!bajarMuerte)
        {
            yield return new WaitForSeconds(1f);
            ch.center = new Vector3(0, 1.7f, 0);
            transform.position -= new Vector3(0, 0.3f, 0);
            bajarMuerte = true;
        }
        yield return null;
    }
    #endregion
}
