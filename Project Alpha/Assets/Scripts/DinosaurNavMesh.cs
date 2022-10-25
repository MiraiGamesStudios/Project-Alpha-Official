using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DinosaurNavMesh : MonoBehaviour
{
    //[SerializeField] private List<Transform> movePositionTransform;
    public List<Transform> movePositionTransform;
    private NavMeshAgent naveMeshAgent;

    int i = 0;

    private void Awake()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        naveMeshAgent.destination = movePositionTransform[i].position;
        if(Vector3.Distance(this.transform.position, movePositionTransform[i].position) < 3) { 
            i++;
            if (i == 4) { i = 0; }
        }
    }
}
