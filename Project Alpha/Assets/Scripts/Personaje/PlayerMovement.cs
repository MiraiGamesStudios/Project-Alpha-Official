using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public new Transform camera;
    public float speed = 4;
    public float gravity = -9.8f;

    public LifeStamina VidaStamina;
    public GameObject panelDeath;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetFloat("ArmaElegida", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(VidaStamina.death == true)
        {
            characterController.center.Set(0.21f, 0.7f, 0.28f);
            animator.SetBool("Morir", true);
            panelDeath.SetActive(true);
            

        }
        else
        {
            calculateMovement();
            move();
        }
    }

    void calculateMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0;

        if (hor != 0 || ver != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            movement = direction * speed * movementSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(camera.forward), 0.2f);
        }

        movement.y += gravity * Time.deltaTime;
        characterController.Move(movement);

        animator.SetFloat("Multiplicador", speed);
    }

    void move()
    {
        if (Input.GetKey("w"))
        {
            if (VidaStamina.outStamina == false)
            {
                if (Input.GetKey("left shift"))
                {
                    speed = 7;
                    animator.SetFloat("Xaxis", 3.0f, 0.1f, Time.deltaTime);
                }
                else
                {
                    animator.SetFloat("Xaxis", 2.0f, 0.1f, Time.deltaTime);
                    speed = 4;
                }
            }
            else
            {
                speed = 1;
                //ANIMACION CANSADO
            }
        }
        else if (Input.GetKey("s"))
        {
            speed = 5;
            animator.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Mouse0)){
            animator.SetBool("Atacar", true);
        }
    }

    
}
