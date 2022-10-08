using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    public string name;
    public float speed = 4;
    public float life;
    private Animator anim;
    public bool anim0 = false;
    public bool anim1 = false;
    public bool anim2 = false;
    public bool anim3 = false;
    public bool anim4 = false;

    public GameObject quemadura;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        quemadura = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (anim0 == true)
        {
            //andar
            anim.SetFloat("Xaxis", 0.5f, 0.1f, Time.deltaTime);
            anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
        }else if (anim1 == true)
        {
            //correr
            anim.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
            anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
        }
        else if (anim2 == true)
        {
            //saltar
            anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
            anim.SetFloat("Yaxis", 0.5f, 0.1f, Time.deltaTime);
        }
        else if (anim3 == true)
        {
            //atacar
            anim.SetFloat("Xaxis", 1.0f, 0.1f, Time.deltaTime);
            anim.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
        }
        else if (anim4 == true)
        {
            //morir
            anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
            anim.SetFloat("Yaxis", 1.0f, 0.1f, Time.deltaTime);
        }
        else 
        {
            //idle
            anim.SetFloat("Xaxis", 0.0f, 0.1f, Time.deltaTime);
            anim.SetFloat("Yaxis", 0.0f, 0.1f, Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "TORCH")
        {
            quemadura.SetActive(true);
            for (int i = 0; i <= 10; i++)
            {

                life--;
                Debug.Log(name + "Quemandose: " + life);
            }
            //quemadura.SetActive(false);


        }/*else if(collider.gameObject.tag == "Weapon")
        {
            life -= 10;
            Debug.Log("Vida del dinosaurio: " + life);
        }*/
    }
}
