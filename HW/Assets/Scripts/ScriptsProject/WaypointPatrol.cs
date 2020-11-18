using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;

    int m_CurrentWaypointIndex;

    void Start ()
    {
        navMeshAgent.SetDestination (waypoints[0].position);
        navMeshAgent.speed = Random.Range(0.5f, 2f);
    }

    void Update ()
    {
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && waypoints.Length != 0)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        }
    }

    public void SetWaypoint(Transform[] wayPoints)
    {
        waypoints = wayPoints;
    }
}
