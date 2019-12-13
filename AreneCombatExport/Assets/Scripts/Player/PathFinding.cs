using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{

    [SerializeField]
    private Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<NavMeshAgent>().remainingDistance < 3)
        {
            GoToTarget();
        }
    }

    private void GoToTarget()
    {
        GetComponent<NavMeshAgent>().SetDestination(targets[Random.Range(0,targets.Length)].position);
    }
}
