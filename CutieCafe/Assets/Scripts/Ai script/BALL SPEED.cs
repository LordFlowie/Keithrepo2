using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class BALLSPEED : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent navAgent;
    private float changeDirectionCooldown = 1.5f;
    private float lastDirectionChangeTime;
    public float movementForce = 3f;
    public float speedThreshold = 2f;

    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isIdle = false;
    public float idleTime = 2f; 



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        MoveToNextWaypoint();
    }


    void FixedUpdate()
    {
        if (!isIdle && waypoints.Length > 0)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 1f)
            {
                StartCoroutine(IdleAtWaypoint());
            }
        }
    }

    IEnumerator IdleAtWaypoint()
    {
        isIdle = true;
        yield return new WaitForSeconds(idleTime);
        isIdle = false;
        MoveToNextWaypoint();
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        navAgent.SetDestination(waypoints[currentWaypointIndex].transform.position);
    }
}

