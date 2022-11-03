using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int arma;

    public List<GameObject> weapons;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        arma = 0;
    }

    // Update is called once per frame
    void Update()
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
}
