using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DinosaurNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent naveMeshAgent;

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
        naveMeshAgent.destination = movePositionTransform.position;
    }
}
