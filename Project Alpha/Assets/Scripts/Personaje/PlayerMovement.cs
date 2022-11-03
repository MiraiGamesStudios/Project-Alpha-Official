using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    Vector3 movementInput = Vector3.zero;
    
    public GameObject cam;
    public GameObject cineMchine;
    public float speed;
    public float gravity;

    public LifeStamina VidaStamina;
    public GameObject panelDeath;
    public GameObject HUD;

    Rigidbody rb;
    CapsuleCollider capsule;

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
        else
        {
            calculateMov();
            move();
        }
    }
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

    private void FixedUpdate()
    {
        Move(movementInput);
    }

    void Move(Vector3 direction)
    {
        rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cam.transform.forward), 0.2f);

        animator.SetFloat("Multiplicador", speed / 2);
    }

    void move()
    {
        if (Input.GetKey("w"))
        {
            if (VidaStamina.outStamina == false) // Si tiene stamina entra
            {
                if (Input.GetKey("left shift")) //Correr
                {
                    
                    speed = 8;
                    animator.SetFloat("Xaxis", 3.0f, 0.1f, Time.deltaTime);

                    if (Input.GetKey("d"))
                    {
                        animator.SetFloat("Yaxis", -1.0f, 0.1f, Time.deltaTime);
                    }
                    else if (Input.GetKey("a"))
                    {
                        animator.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
                    }
                    else
                    {
                       
                        animator.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                    }
                }
                else // Andar
                {
                    
                    speed = 4;
                    animator.SetFloat("Xaxis", 2.0f, 0.1f, Time.deltaTime);

                    if (Input.GetKey("d"))
                    {
                        animator.SetFloat("Yaxis", -1.0f, 0.1f, Time.deltaTime);
                    }
                    else if (Input.GetKey("a"))
                    {
                        animator.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
                    }
                    else
                    {
                        animator.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
                    }
                }
            }
            else //No tiene stamina, por lo tanto, esta cansado
            {
                
                speed = 1;
                animator.SetFloat("Xaxis", 4.0f, 0.1f, Time.deltaTime);
            }
        }


        else if (Input.GetKey("s")) // Caminar hacia atras
        {
            speed = 3;
            animator.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);

            if (Input.GetKey("d"))
            {
                animator.SetFloat("Yaxis", -1.0f, 0.1f, Time.deltaTime);
            }
            else if (Input.GetKey("a"))
            {
                animator.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
            }
        }


        else if (Input.GetKey("d")) // Caminar derecha
        {
            speed = 3;
            animator.SetFloat("Xaxis", 2.0f, 0.1f, Time.deltaTime);
            animator.SetFloat("Yaxis", -1.0f, 0.1f, Time.deltaTime);
        }


        else if (Input.GetKey("a")) // Caminar izquierda
        {
            speed = 3;
            animator.SetFloat("Xaxis", 2.0f, 0.1f, Time.deltaTime);
            animator.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
        }


        else //Idle
        {
            animator.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
            animator.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
        }

    }

    IEnumerator Morir()
    {
        movementInput = (new Vector3(0, 0, 0));
        cineMchine.SetActive(false);

        animator.SetBool("Morir", true);

        //GetComponent<Event_pegar>().enabled = false;

        yield return new WaitForSeconds(2.2f);

        capsule.height = 1.0f;
        HUD.SetActive(false);
        panelDeath.SetActive(true);

        yield return null;
    }
    
}
