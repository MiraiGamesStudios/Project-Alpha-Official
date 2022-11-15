using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    private Animator animator;

    Vector3 movementInput = Vector3.zero;
    
    public GameObject cam;
    public GameObject cineMchine;

    public float speedInicial;
    float speed;
    public float gravity;

    public LifeStamina VidaStamina;
    public GameObject panelDeath;
    public GameObject HUD;

    Rigidbody rb;
    CapsuleCollider capsule;

    public GameObject rayos;
    public GameObject hielo;

    bool stun = false;

    public Joystick joystickMove;

    #endregion

    #region Metodos Unity
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        capsule = GetComponent<CapsuleCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("ArmaElegida", 0);

        Physics.gravity *= gravity;
        animator.SetBool("Atacar", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(VidaStamina.death == true)
        {
            StartCoroutine(Morir());            
        }
        else if (stun)
        {
            movementInput = Vector3.zero;
        }
        else
        {
            calculateMov();
            moveAnimations();
        }

        //MoveJoystick();

    }

    private void FixedUpdate()
    {
        Move(movementInput);
    }

    private void OnEnable()
    {
        AtaqueElectrico.AElectricoStun += comenzarCorrutinaStun;
        AtaqueHielo.AHielo += comenzarCorrutinaCongelado;
    }

    private void OnDisable()
    {
        AtaqueElectrico.AElectricoStun -= comenzarCorrutinaStun;
        AtaqueHielo.AHielo -= comenzarCorrutinaCongelado;

    }
    #endregion

    #region Movimiento

    void calculateMov()
    {

        Vector3 forward = Vector3.zero; 
        Vector3 right = Vector3.zero;
        Vector3 up = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            forward = cam.transform.forward;
            forward.y = 0;
            forward.Normalize();


        }
        else if (Input.GetKey(KeyCode.S))
        {
            forward = -cam.transform.forward;
            forward.y = 0;
            forward.Normalize();
        }

        if (Input.GetKey(KeyCode.D))
        {
            right = cam.transform.right;
            right.y = 0;
            right.Normalize();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            right = -cam.transform.right;
            right.y = 0;
            right.Normalize();
        }

        movementInput = forward + right;

    }

    void Move(Vector3 direction)
    {
        rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cam.transform.forward), 0.2f);

        animator.SetFloat("Multiplicador", speed / 2);
    }

    void MoveJoystick()
    {
        rb.velocity = new Vector3(joystickMove.Horizontal * speed, rb.velocity.y, joystickMove.Vertical * speed);
    }

    #endregion

    #region Animaciones

    void moveAnimations()
    {
        if (Input.GetKey("w"))
        {
            if (VidaStamina.outStamina == false) // Si tiene stamina entra
            {
                if (Input.GetKey("left shift")) //Correr
                {
                    
                    speed = speedInicial*2;
                    animator.SetFloat("Yaxis", 2.0f, 0.1f, Time.deltaTime);
                    animator.SetFloat("Cansancio", 0.0f, 0.1f, Time.deltaTime);

                    if (Input.GetKey("d"))
                    {
                        animator.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
                    }
                    else if (Input.GetKey("a"))
                    {
                        animator.SetFloat("Xaxis", -1.0f, 0.1f, Time.deltaTime);
                    }
                    else
                    {
                       
                        animator.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                    }
                }
                else // Andar
                {
                    
                    speed = speedInicial;
                    animator.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
                    animator.SetFloat("Cansancio", 0.0f, 0.1f, Time.deltaTime);

                    if (Input.GetKey("d"))
                    {
                        animator.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
                    }
                    else if (Input.GetKey("a"))
                    {
                        animator.SetFloat("Xaxis", -1.0f, 0.1f, Time.deltaTime);
                    }
                    else
                    {
                        animator.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
                    }
                }
            }
            else //No tiene stamina, por lo tanto, esta cansado
            {
                
                speed = speedInicial/4;
                animator.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
                animator.SetFloat("Cansancio", 1.0f, 0.1f, Time.deltaTime);
            }
        }


        else if (Input.GetKey("s")) // Caminar hacia atras
        {
            speed = speedInicial/4*3;
            animator.SetFloat("Yaxis", -1.0f, 0.1f, Time.deltaTime);

            if (Input.GetKey("d"))
            {
                animator.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
            }
            else if (Input.GetKey("a"))
            {
                animator.SetFloat("Xaxis", -1.0f, 0.1f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
            }
        }


        else if (Input.GetKey("d")) // Caminar derecha
        {
            speed = speedInicial / 4 * 3;
            animator.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
            animator.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
        }


        else if (Input.GetKey("a")) // Caminar izquierda
        {
            speed = speedInicial / 4 * 3;
            animator.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
            animator.SetFloat("Xaxis", -1.0f, 0.1f, Time.deltaTime);
        }


        else //Idle
        {
            animator.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
            animator.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
        }

    }

    #endregion

    void comenzarCorrutinaStun(int seg)
    {
        StartCoroutine(Stunned(seg));
    }

    void comenzarCorrutinaCongelado(int a)
    {
        StartCoroutine(congelado());
    }

    IEnumerator Morir()
    {
        movementInput = (new Vector3(0, 0, 0));
        cineMchine.SetActive(false);

        animator.SetBool("Morir", true);
        animator.SetLayerWeight(2, 1);

        //GetComponent<Event_pegar>().enabled = false;

        yield return new WaitForSeconds(2.2f);

        capsule.height = 1.0f;
        HUD.SetActive(false);
        panelDeath.SetActive(true);

        yield return null;
    }

    IEnumerator Stunned(int seg)
    {
        stun = true;
        animator.enabled = false;
        cineMchine.SetActive(false);
        rayos.SetActive(true);
        GetComponent<Disparo>().enabled = false;

        yield return new WaitForSeconds(seg);

        stun = false;
        animator.enabled = true;
        cineMchine.SetActive(true);
        rayos.SetActive(false);
        GetComponent<Disparo>().enabled = true;

        yield return null;
    }

    IEnumerator congelado()
    {
        float speedCambiada = speedInicial;

        hielo.SetActive(true);
        speedInicial = speedCambiada/4;

        yield return new WaitForSeconds(5);

        speedInicial = speedCambiada;
        hielo.SetActive(false);

    }

}
