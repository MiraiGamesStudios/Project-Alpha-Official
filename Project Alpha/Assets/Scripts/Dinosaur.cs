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
                avancePersonaje = 0.0f;

                break;
        }

        /*saltar
            anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
            anim.SetFloat("Yaxis", 0.5f, 0.1f, Time.deltaTime);*/
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "TORCH" && quemadura.active == false)
        {
            life -= 10;

            GameObject textGO = Instantiate(damageText, transform.position, Quaternion.identity);
            //textGO.GetComponent<TextMeshPro>().SetText(10);
            Destroy(textGO, 5);

            quemadura.SetActive(true);
            StartCoroutine(quemarse());


        }else if(collider.gameObject.tag == "Weapon")
        {
            life -= 10;
            Debug.Log(name + "Vida del dinosaurio: " + life);
        }

        if(collider.gameObject.tag == "Dinosaur" && collider.transform.GetChild(2).gameObject.active == true && quemadura.active == false)
        {
            quemadura.SetActive(true);
            StartCoroutine(quemarse());
        }
    }

    IEnumerator quemarse()
    {
        for (int i = 0; i < 10; i++)
        {
            life--;
            Debug.Log(name + "Quemandose: " + life);
            yield return new WaitForSeconds(1f);
        }

        quemadura.SetActive(false);


        yield return null;
    }

}
