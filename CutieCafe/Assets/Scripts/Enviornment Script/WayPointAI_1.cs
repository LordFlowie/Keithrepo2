using UnityEngine;
using UnityEngine.AI;

public class WayPointAI_1 : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Vector3 destination;

    public bool isVisible, isAudible, isClose;
    public bool isIdleAtWaypoint = false; // Tracks whether NPC is idle at a waypoint

    public Transform target;
    public AudioSource audioSource;  // Reference to the AudioSource
    public AudioClip targetAudioClip;  // The specific audio clip you're looking for

    public float sightDistance = 10f;  // Maximum sight distance
    public float closeDistance = 2.5f; // Distance to consider 'close'
    public float waitTimeAtWaypoint = 2f; // Time to wait at each waypoint (in seconds)

    private int nextIndex;
    public GameObject[] waypoints;

    private float waitTimer = 0f; // Timer to track wait time at the waypoint

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
            SeekFunction(); // Chase the target
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
            // Check if the target is within audible range
            if (Vector3.Distance(transform.position, target.position) < closeDistance)
            {
                // Check if the specific audio clip is playing
                if (audioSource.isPlaying && audioSource.clip == targetAudioClip)
                {
                    isAudible = true;  // The sound is audible and the target is nearby
                }
                else
                {
                    isAudible = false;  // The sound is not audible, or it's not the target sound
                }
            }
            else
            {
                isAudible = false;  // Target is not close enough
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


