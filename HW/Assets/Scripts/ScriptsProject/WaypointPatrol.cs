using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask mask;
    
    private RaycastHit hit;
    private bool isPatrol = true;    
    private int m_CurrentWaypointIndex = 0;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<JohnLemonMover>().transform;
    }

    void Start ()
    {
        navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        navMeshAgent.speed = Random.Range(1f, 3f);
    }   

    private void FixedUpdate()
    {
        Color c = Color.red;        

        Vector3 startPosition = CalculateOffset(transform.position, 1.0f);
        Vector3 directionRaycast = CalculateOffset(player.position, 1.0f) - startPosition;

        var raycast = Physics.Raycast(startPosition, directionRaycast, out hit, directionRaycast.magnitude, mask);

        if (raycast)
        {
            if (hit.transform.CompareTag("Player"))
            {
                c = Color.blue;
                FollowTarget();
            }
            else
            {
                Comeback();
            }
        }

        Debug.DrawLine(startPosition, CalculateOffset(player.position, 1f), c);
    }

    #region Method

    public void SetWaypoint(Transform[] wayPoints)
    {
        waypoints = wayPoints;
    }

    private Vector3 CalculateOffset(Vector3 position, float offset)
    {
        position.y += offset;
        return position;
    }

    private void Comeback()
    {
        if (isPatrol == true && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
        else if (!isPatrol)
        {
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            isPatrol = true;
        }
    }

    private void FollowTarget()
    {
        isPatrol = false;
        navMeshAgent.SetDestination(player.position);
    }

    #endregion
}
