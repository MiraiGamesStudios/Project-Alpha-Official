using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Suit : MonoBehaviour
{
    #region Variable

    public float speed = 4;
    public float life;
    bool restado = true;

    public GameManagerContemporaneo gm;

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
    public Status statusSuit = Status.quieto;

    public GameObject arma;
    public delegate void _da�arPersonajePeriodico(int da�o);
    public static event _da�arPersonajePeriodico da�arPersonajePeriodico;

    public bool golpeadoExplosion = false;

    #endregion

    #region Metodos Unity

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            statusSuit = Status.muerto;
            if (restado)
            {
                restado = false;
                gm.enemigosVivos--;
            }

        }

        // Integrar posicion en avance
        m_currentV = Mathf.Lerp(m_currentV, avancePersonaje, Time.deltaTime * m_interpolation);
        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;

        FSMSuit();
    }

    #endregion

    #region FSM
    public void FSMSuit()
    {
        switch (statusSuit)
        {
            case Status.quieto:
                //idle
                anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                if (Vector3.Distance(this.transform.position, player.transform.position) < 30)
                {
                    statusSuit = Status.corriendo;
                }
                break;

            case Status.deambulando:
                //andar
                anim.SetFloat("Xaxis", 0.5f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                if (Vector3.Distance(this.transform.position, player.transform.position) < 30)
                {
                    statusSuit = Status.corriendo;
                    //this.gameObject.GetComponent<DinosaurNavMesh>().naveMeshAgent.enabled = !this.gameObject.GetComponent<DinosaurNavMesh>().naveMeshAgent.enabled;
                    //this.gameObject.GetComponent<DinosaurNavMesh>().enabled = !this.gameObject.GetComponent<DinosaurNavMesh>().enabled;
                }
                break;

            case Status.corriendo:
                //correr
                Avanzar(player.transform.position);
                anim.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                if (this.EstaEnObjetivo(player.transform.position))
                {
                    avancePersonaje = 0.0f;
                    statusSuit = Status.atacando;
                }
                break;

            case Status.atacando:
                //atacar
                Alinear(player.transform.position);
                anim.SetBool("Atacar", true);
                anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);

                if (!this.EstaEnObjetivo(player.transform.position))
                {
                    avancePersonaje = 1.0f;
                    statusSuit = Status.corriendo;
                }
                break;

            case Status.muerto:
                //morir
                anim.SetLayerWeight(2, 1);
                eliminarme();
                anim.SetBool("Morir", true);
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
            gm.GetComponent<GameManagerContemporaneo>().suitArea1.Remove(this.gameObject);
        }
        else if (area == 2)
        {
            gm.GetComponent<GameManagerContemporaneo>().suitArea2.Remove(this.gameObject);
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

    #region Metodos Suit

    public void quitarVida(int da�o, string numDa�o)
    {
        if (!golpeadoExplosion && statusSuit != Status.muerto)
        {
            life -= da�o;
            numerosPantalla(da�o, numDa�o);
            StartCoroutine(resetearGolpeExplosion());
        }
    }

    void numerosPantalla(float tama�o, string da�o)
    {
        Vector3 posicion = new Vector3(this.transform.position.x + 0.5f + Random.Range(-0.3f, 0.3f), this.transform.position.y + 2.8f + Random.Range(0f, 0.5f), this.transform.position.z + Random.Range(-0.5f, 0.5f));

        GameObject textGO = Instantiate(damageText, posicion, Quaternion.LookRotation(this.transform.forward));
        textGO.GetComponentInChildren<TextMeshPro>().SetText(da�o);
        textGO.GetComponentInChildren<TextMeshPro>().fontSize = tama�o;
        Destroy(textGO, 1);
    }


    void Golpe()
    {
        if (arma.GetComponent<PeriodicoS>().target?.tag == "Player")
        {
            da�arPersonajePeriodico(10);
        }
    }

    void Resetear()
    {
        arma.GetComponent<PeriodicoS>().target = null;
    }

    IEnumerator resetearGolpeExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        golpeadoExplosion = false;
    }
    #endregion
}
