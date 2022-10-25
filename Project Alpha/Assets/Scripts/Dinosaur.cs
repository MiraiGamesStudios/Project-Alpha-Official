using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinosaur : MonoBehaviour
{
    public string name;
    public float speed = 4;
    public float life;
    private Animator anim;

    private float avancePersonaje = 0.0f;
    [SerializeField] private float epsilonDistancia = 3f; // Distancia minima para alcanzar objetivo
    private float m_currentV = 0;                   // Posicion de avance actual 
    private readonly float m_interpolation = 10;    // Multiplicador para el paso de integracion
    [SerializeField] private float m_moveSpeed = 1;         // Velocidad de avance del personaje

    public GameObject quemadura;

    private enum Status { quieto, deambulando, corriendo, atacando, muerto};
    Status statusDinosaur = Status.deambulando;

    GameObject player;

    public GameObject damageText;
    public GameObject posDaño;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        quemadura = transform.GetChild(2).gameObject;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            statusDinosaur = Status.muerto;
        }

        // Integrar posicion en avance
        m_currentV = Mathf.Lerp(m_currentV, avancePersonaje, Time.deltaTime * m_interpolation);
        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;

        FSMDinosaur();
    }

    void FSMDinosaur()
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
                if (!this.EstaEnObjetivo(player.transform.position))
                {
                    avancePersonaje = 1.0f;
                    statusDinosaur = Status.corriendo;
                }
                break;

            case Status.muerto:
                //morir
                anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                anim.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
                Destroy(this.gameObject, 2);
                avancePersonaje = 0.0f;

                break;
        }

    }

    ///  Activa el avance del personaje hacia un objetivo. 
    ///  Si no estaba mirando hacia el objetivo, primero se alineara de forma automatica.
    ///  
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

    public void perderVida()
    {
            life -= 10;
            numerosPantalla(10, "10");
            
            Debug.Log(name + "Vida del dinosaurio: " + life);
    }

    public void OnTriggerEnter(Collider collider)
    {
        //Contagio del fuego entre dinosaurios
        if (collider.gameObject.tag == "Dinosaur" && collider.transform.GetChild(2).gameObject.active == true && quemadura.active == false)
        {
            quemadura.SetActive(true);
            StartCoroutine(quemarse());
        }

    }


    IEnumerator quemarse()
    {
        quemadura.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            life--;

            numerosPantalla(3, "1");

            Debug.Log(name + "Quemandose: " + life);
            yield return new WaitForSeconds(1f);
        }

        quemadura.SetActive(false);


        yield return null;
    }

    void numerosPantalla(float tamaño, string daño)
    {
        Vector3 posicion = new Vector3(posDaño.transform.position.x + Random.Range(-2.0f, 2.0f), posDaño.transform.position.y + Random.Range(0f, 2.0f), posDaño.transform.position.z + Random.Range(-2.0f, 2.0f));

        GameObject textGO = Instantiate(damageText, posicion, Quaternion.LookRotation(player.transform.forward));
        textGO.GetComponentInChildren<TextMeshPro>().SetText(daño);
        textGO.GetComponentInChildren<TextMeshPro>().fontSize = tamaño;
        Destroy(textGO, 1);
    }

}
