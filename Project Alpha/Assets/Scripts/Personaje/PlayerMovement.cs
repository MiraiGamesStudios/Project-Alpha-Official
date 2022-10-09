using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    Vector3 movementInput = Vector3.zero;
    Vector3 jumpInput = Vector3.zero;

    public new Transform camera;
    public float speed;
    public float gravity;

    public LifeStamina VidaStamina;
    public GameObject panelDeath;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("ArmaElegida", 0f);

        Physics.gravity *= gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if(VidaStamina.death == true)
        {
            animator.SetBool("Morir", true);
            panelDeath.SetActive(true);
            
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
            forward = camera.forward;
            forward.y = 0;
            forward.Normalize();


        }
        else if (Input.GetKey(KeyCode.S))
        {
            forward = -camera.forward;
            forward.y = 0;
            forward.Normalize();
        }

        if (Input.GetKey(KeyCode.D))
        {
            right = camera.right;
            right.y = 0;
            right.Normalize();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            right = -camera.right;
            right.y = 0;
            right.Normalize();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            up.y = 0.1f;
            
        }

        //up.y += up.y + gravity * Time.deltaTime;
        //up.y = Mathf.Clamp(up.y, 0);
        movementInput = forward + right;
        jumpInput = up;

      

    }
    private void FixedUpdate()
    {
        Move(movementInput, jumpInput);
    }

    void Move(Vector3 direction, Vector3 up)
    {
        //rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
        rb.MovePosition(rb.position + up + direction.normalized * speed * Time.fixedDeltaTime);
        //transform.position += direction.normalized * speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(camera.forward), 0.2f);

        animator.SetFloat("Multiplicador", speed / 2);
    }

    //void calculateMovement()
    //{
    //    float hor = Input.GetAxis("Horizontal");
    //    float ver = Input.GetAxis("Vertical");
    //    Vector3 movement = Vector3.zero;
    //    float movementSpeed = 0;

    //    if (hor != 0 || ver != 0)
    //    {
    //        Vector3 forward = camera.forward;
    //        forward.y = 0;
    //        forward.Normalize();

    //        Vector3 right = camera.right;
    //        right.y = 0;
    //        right.Normalize();

    //        Vector3 direction = forward * ver + right * hor;
    //        movementSpeed = Mathf.Clamp01(direction.magnitude);
    //        direction.Normalize();

    //        movement = direction * speed * movementSpeed * Time.deltaTime;

    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(camera.forward), 0.2f);
    //    }

    //    movement.y += gravity * Time.deltaTime;
    //    characterController.Move(movement);

    //    animator.SetFloat("Multiplicador", speed/2);
    //}

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

        if (Input.GetKey(KeyCode.Mouse0)){
            animator.SetBool("Atacar", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Saltar", true);
        }
    }

    
}
