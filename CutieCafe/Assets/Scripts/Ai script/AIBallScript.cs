using UnityEngine;

public class AIBallScript : MonoBehaviour
{
    public GameObject playerSphere;
    public float closeDistance = 5f; // The distance within which the AI will follow the player
    const float MAX_MOVE_DISTANCE = 200.0f;
    const float DECELERATION_FACTOR = 0.6f;
    float moveDistance;
    Vector3 source;
    Vector3 target;
    Vector3 outputVelocity;
    Vector3 directionToTarget;
    Vector3 velocityToTarget;
    float distanceToTarget;
    float speed;

    void FixedUpdate()
    {
        moveDistance = MAX_MOVE_DISTANCE * Time.deltaTime;
        source = transform.position;

        // Check if playerSphere exists
        if (playerSphere != null)
        {
            // Check if the player is within the closeDistance
            distanceToTarget = Vector3.Distance(transform.position, playerSphere.transform.position);

            // If the player is within the specified distance, update the target to the player's position
            if (distanceToTarget < closeDistance)
            {
                target = playerSphere.transform.position;
                outputVelocity = Seek(source, target, moveDistance); // Seek towards the player
            }
            else
            {
                // If the player is too far, set a default target (center of the game area)
                target = Vector3.zero;
                outputVelocity = Seek(source, target, moveDistance); // Move towards the center or a different target
            }

            // Apply movement to the Rigidbody
            GetComponent<Rigidbody>().AddForce(outputVelocity, ForceMode.VelocityChange);
        }
        else
        {
            // If the playerSphere is not assigned, set the target to the center of the game area
            target = Vector3.zero;
            outputVelocity = Seek(source, target, moveDistance);
            GetComponent<Rigidbody>().AddForce(outputVelocity, ForceMode.VelocityChange);
        }
    }

    private Vector3 Seek(Vector3 source, Vector3 target, float moveDistance)
    {
        directionToTarget = Vector3.Normalize(target - source);
        velocityToTarget = moveDistance * directionToTarget;

        // Return the velocity needed to move towards the target
        return velocityToTarget - GetComponent<Rigidbody>().linearVelocity;
    }

    private Vector3 Arrive(Vector3 source, Vector3 target)
    {
        distanceToTarget = Vector3.Distance(source, target);
        directionToTarget = Vector3.Normalize(target - source);
        speed = distanceToTarget / DECELERATION_FACTOR;
        velocityToTarget = speed * directionToTarget;

        return velocityToTarget - GetComponent<Rigidbody>().linearVelocity;
    }
}

