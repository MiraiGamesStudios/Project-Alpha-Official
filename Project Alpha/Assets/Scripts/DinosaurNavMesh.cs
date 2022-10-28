using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DinosaurNavMesh : MonoBehaviour
{
    //[SerializeField] private List<Transform> movePositionTransform;
    public GameObject[] movePositionTransform;
    public NavMeshAgent naveMeshAgent;

    int i = 0;
    //int j = 1;
    int areaDin;

    private void Awake()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        areaDin = GetComponent<Dinosaur>().area;

        if (this.gameObject.name == "Trex"){
            movePositionTransform = GameObject.FindGameObjectsWithTag("TrexTarget");
        }else if (areaDin == 1)//velocirraptors del area 1
        {
            movePositionTransform = GameObject.FindGameObjectsWithTag("Area1Target");
        }else if (areaDin==2)
        {
            movePositionTransform = GameObject.FindGameObjectsWithTag("Area2Target");
        }
        naveMeshAgent.destination = movePositionTransform[i].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Trex")
        {
            if (Vector3.Distance(this.transform.position, movePositionTransform[i].transform.position) < 3)
            {
                i++;
                if (i == 4) { i = 0; }
            }
        }else if (areaDin == 1)//si el dinosaurio es del area 1 
        {
            if (Vector3.Distance(this.transform.position, movePositionTransform[i].transform.position) < 3)
            {
                i++;
                if (i == 6) { i = 0; }
            }
        }else if (areaDin == 2)
        {
            if (Vector3.Distance(this.transform.position, movePositionTransform[i].transform.position) < 3)
            {
                i++;
                if (i == 7) { i = 0; }
            }
        }

    }
}
