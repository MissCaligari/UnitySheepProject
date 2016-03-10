using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
public class SheepWaypoints : MonoBehaviour
{
    public GameObject[] myPos;
    public bool isPatrolling = true;

    private int myNextPos;
    private GameObject player;
    public NavMeshAgent navigationAgent;

    void Start ()
    {
        navigationAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update ()
    {
        if (isPatrolling)
            Partol();
        else
            navigationAgent.SetDestination(player.transform.position); ;
    }
    void Partol()
    {
        //navigationAgent.stoppingDistance = 0.0f;
        //navigationAgent.speed = 1.5f;
        //navigationAgent.acceleration = 3.0f;

        if (!navigationAgent.pathPending)
        {
            if (navigationAgent.remainingDistance <= navigationAgent.stoppingDistance)
            {
                if (!navigationAgent.hasPath || navigationAgent.velocity.sqrMagnitude == 0f)
                {
                    myNextPos = Random.Range(0, myPos.Length);
                    navigationAgent.SetDestination(myPos[myNextPos].transform.position);
                }
            }
        }
    }
}
