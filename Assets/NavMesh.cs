using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent myNavMeshAgent;
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        myNavMeshAgent.SetDestination(target.transform.position);
    }
}
