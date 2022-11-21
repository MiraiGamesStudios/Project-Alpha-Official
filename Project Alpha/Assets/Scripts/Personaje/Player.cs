using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int arma;
    public int armaIzq;
    public int armaDch;

    public List<GameObject> weapons;

    private Animator animator;

    public GameObject botonArmaIzq;
    public GameObject botonArmaDch;

    public int Disp = 0;

    private void Awake()
    {
        Disp = FindObjectOfType<Dispositivo>().dispositivo;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        arma = 0;

        if(Disp == 1)
        {
            botonArmaIzq.SetActive(true);
            botonArmaDch.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Disp == 1)
        {
            elegirArmaMovil();
        }
        else
        {
            elegirArmaPC();
        }
        
    }

    public void elegirArmaPC()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            animator.SetInteger("ArmaElegida", 0);
            arma = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            animator.SetInteger("ArmaElegida", 1);
            arma = 1;

        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            animator.SetInteger("ArmaElegida", 0);
            arma = 3;
        }
    }

    public void elegirArmaMovil()
    {
        switch (arma)
        {
            case 0:
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
                animator.SetInteger("ArmaElegida", 0);
                break;
            case 1:
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weapons[2].SetActive(false);
                animator.SetInteger("ArmaElegida", 1);
                break;
            case 2:
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
                animator.SetInteger("ArmaElegida", 0);
                break;
        }
    }

    public void CambiarArmaDcha()
    {
        switch (arma)
        {
            case 0:            //porra
                arma = 1;      //lanza
                break;
            case 1:            //lanza 
                arma = 2;      //antorcha
                break;
            case 2:            //antorcha 
                arma = 0;      //porra
                break;
        }
    }
    public void CambiarArmaIzq()
    {
        switch (arma)
        {
            case 0:            //porra
                arma = 2;      //antorcha
                break;
            case 1:            //lanza 
                arma = 0;      //porra
                break;
            case 2:            //antorcha 
                arma = 1;      //lanza
                break;
        }
    }
}
