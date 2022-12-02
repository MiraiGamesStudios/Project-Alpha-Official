using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinosaur : MonoBehaviour
{
    public delegate void _dañoRecibido();
    public static event _dañoRecibido dañoRecibido;

    public GameManager gm;
    Rigidbody rb;

    public float speed = 4;
    public float life;

    private Animator anim;
    public List<Collider> colliders;
    public GameObject quemadura;

    public bool quemandome;
    public bool quemazon;
    public bool muerto;

    public int area = 0;

    GameObject player;
    GameObject target;

    public enum Tipo {Velocirraptor, Triceratops, Alphasaurio, TRex };
    [SerializeField] public Tipo tipo;

    private float avancePersonaje = 0.0f;
    [SerializeField] private float epsilonDistancia = 3f; // Distancia minima para alcanzar objetivo
    private float m_currentV = 0;                   // Posicion de avance actual 
    private readonly float m_interpolation = 10;    // Multiplicador para el paso de integracion
    [SerializeField] private float m_moveSpeed = 1;         // Velocidad de avance del personaje

    public enum Status { quieto, deambulando, corriendo, atacando, muerto};
    public Status statusDinosaur = Status.deambulando;

    bool restado = true;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, 5f, 0);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        quemadura = transform.GetChild(2).gameObject;

        player = GameObject.FindGameObjectWithTag("Player");
        muerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            statusDinosaur = Status.muerto;
            if (restado) {
                restado = false;
                gm.dinosVivos--;
            }
           
        }

        // Integrar posicion en avance
        m_currentV = Mathf.Lerp(m_currentV, avancePersonaje, Time.deltaTime * m_interpolation);
        transform.position += transform.forward * m_currentV  * m_moveSpeed * Time.deltaTime;
        

        FSMDinosaur();
    }
    
    public void FSMDinosaur()
    {
        switch (statusDinosaur)
        {
            case Status.quieto:
                //idle
                anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                break;

            case Status.deambulando:
                //andar
                anim.SetFloat("Xaxis", 0.5f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                if (Vector3.Distance(this.transform.position, player.transform.position)<30)
                {
                    statusDinosaur = Status.corriendo;
                    this.gameObject.GetComponent<DinosaurNavMesh>().naveMeshAgent.enabled = !this.gameObject.GetComponent<DinosaurNavMesh>().naveMeshAgent.enabled;
                    this.gameObject.GetComponent<DinosaurNavMesh>().enabled = !this.gameObject.GetComponent<DinosaurNavMesh>().enabled;
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
                    statusDinosaur = Status.atacando;
                }
                break;

            case Status.atacando:
                //atacar
                anim.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);

                Alinear(player.transform.position);
                rb.isKinematic = true;
                if (!this.EstaEnObjetivo(player.transform.position))
                {
                    avancePersonaje = 1.0f;
                    statusDinosaur = Status.corriendo;
                    rb.isKinematic = false;
                }
                break;

            case Status.muerto:
                //morir
                muerto = true;
                quemadura.SetActive(false);
                eliminarme();
                anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
                Destroy(this.gameObject, 2);
                avancePersonaje = 0.0f;

                break;
        }

    }

    void eliminarme(){
        switch (tipo)
        {
            case Tipo.Velocirraptor:
                if(area == 1)
                {
                    gm.GetComponent<GameManager>().velosArea1.Remove(this.gameObject);
                }else if(area == 2)
                {
                    gm.GetComponent<GameManager>().velosArea2.Remove(this.gameObject);
                }
                break;

            case Tipo.Triceratops:
                if (area == 1)
                {
                    gm.GetComponent<GameManager>().tricesArea1.Remove(this.gameObject);
                }else if (area == 2)
                {
                    gm.GetComponent<GameManager>().tricesArea2.Remove(this.gameObject);
                }
                    break;

            case Tipo.Alphasaurio:
                break;

            case Tipo.TRex:
                break;
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

    

    public void OnTriggerEnter(Collider collider)
    {  
        if(tipo == Tipo.Velocirraptor && collider.transform.root.gameObject.tag == "Player")
        {
            target = collider.transform.root.gameObject;
        }

        if (tipo == Tipo.Triceratops && collider.transform.root.gameObject.tag == "Player")
        {
            target = collider.transform.root.gameObject;
        }

        if (tipo == Tipo.Alphasaurio && collider.transform.root.gameObject.tag == "Player")
        {
            target = collider.transform.root.gameObject;
        }

        if (tipo == Tipo.TRex && collider.transform.root.gameObject.tag == "Player")
        {
            target = collider.transform.root.gameObject;
        }

    }

    void MorderVelocirraptor()
    {
        StartCoroutine(target.GetComponent<LifeStamina>().lifeLost(3));
        target = null;
        if (dañoRecibido != null)
        {
            dañoRecibido();
        }
    }

    void MorderTriceratops()
    {
        StartCoroutine(target.GetComponent<LifeStamina>().lifeLost(5));
        target = null;
        if(dañoRecibido != null)
        {
            dañoRecibido();
        }
    }

    void MorderTRex()
    {
        StartCoroutine(target.GetComponent<LifeStamina>().lifeLost(15));
        target = null;
        if (dañoRecibido != null)
        {
            dañoRecibido();
        }
    }

    void MorderAlpha()
    {

        StartCoroutine(target.GetComponent<LifeStamina>().lifeLost(10));
        target = null;
        if (dañoRecibido != null)
        {
            dañoRecibido();
        }
    }

}
