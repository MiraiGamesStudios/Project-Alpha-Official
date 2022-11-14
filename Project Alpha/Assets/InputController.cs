using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{ 
    public Joystick joysticMove;


    public Rigidbody rb;


    float speed = 10f;


    void Move()
    {
        rb.velocity = new Vector3(joysticMove.Horizontal * speed, rb.velocity.y, joysticMove.Vertical * speed);
    }




    private void Update()
    {
        Move();
    }
}
