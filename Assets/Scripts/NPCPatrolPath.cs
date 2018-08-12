using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrolPath : MonoBehaviour
{

    //Dictates whether the agent waits on each node
    [SerializeField]
    bool patrolWaiting;

    //The total time we wait at each node
    [SerializeField]
    float totalWaitTime = 3f;

    //The probability of switching direction
    [SerializeField]
    float switchProbablity = 0.2f;

    //List of all patrol nodes to visit
    [SerializeField]
    List<Waypoint> patrolPoints;

    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attatched to " + gameObject.name);
        }
        else
        {
            if(patrolPoints!=null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.LogError("Insufficient patrol points for basic patrolling behaviour");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if we're close to the destination
        if (travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;

            //If we're going to wait then wait
            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        //Instead if we're waiting
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= totalWaitTime)
            {
                waiting = false;
                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if(patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
            travelling = true;
        }
    }

    //setlects new patrol point in the available list
    //has small probability to move different direction
    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f, 1f) <= switchProbablity)
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--currentPatrolIndex <0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }
}

