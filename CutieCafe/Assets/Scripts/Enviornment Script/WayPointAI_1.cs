using UnityEngine;
using UnityEngine.AI;

public class WayPointAI_1 : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Vector3 destination;

    public bool isVisible, isAudible, isClose;
    public bool isIdleAtWaypoint = false; 

    public Transform target;
    public AudioSource audioSource;  
    public AudioClip targetAudioClip;

    public float sightDistance = 10f;  
    public float closeDistance = 2.5f; 
    public float waitTimeAtWaypoint = 2f; 

    private int nextIndex;
    public GameObject[] waypoints;

    private float waitTimer = 0f; 

    private void Start()
    {

    }

    void Update()
    {
        CheckVisibility();
        CheckProximity();
        CheckAudio();

        if (isVisible && isClose)
        {
            SeekFunction();
        }
        else if (isVisible && !isClose)
        {
            //PatrolFunction(); // Patrol around waypoints
        }
        else if (!isVisible && !isAudible)
        {
            //IdleFunction(); // Idle when not visible or audible
        }
        else if (!isVisible && isAudible)
        {
            PatrolFunction(); // Patrol if only audible
            //insert if audio played then pay
        }


    }

    void CheckVisibility()
    {
        if (target != null)
        {
            RaycastHit hit;
            Vector3 direction = target.position - transform.position;
            if (Physics.Raycast(transform.position, direction, out hit, sightDistance))
            {
                isVisible = (hit.transform == target);
            }
            else
            {
                isVisible = false;
            }
        }
    }

    void CheckProximity()
    {
        if (target != null)
        {
            isClose = Vector3.Distance(transform.position, target.position) < closeDistance;
        }
    }

    void CheckAudio()
    {
        if (target != null)
        {
            
            if (Vector3.Distance(transform.position, target.position) < closeDistance)
            {
                
                if (audioSource.isPlaying && audioSource.clip == targetAudioClip)
                {
                    isAudible = true;  
                }
                else
                {
                    isAudible = false;  
                }
            }
            else
            {
                isAudible = false;  
            }
        }
    }

    void SeekFunction()
    {
        destination = target.position;  // Chase the target
        isIdleAtWaypoint = false; // NPC is moving
        waitTimer = 0f; // Reset wait timer when chasing
    }

    void PatrolFunction()
    {
        // Check if NPC has reached the current destination (waypoint)
        if (Vector3.Distance(transform.position, destination) < 2.5f)
        {
            isIdleAtWaypoint = true; // Start idling at the waypoint
        }
    }

    void IdleFunction()
    {
        //navMesh.isStopped = true;  // Stop the NPC
        isIdleAtWaypoint = true;   // Set idle flag to true
    }
}


