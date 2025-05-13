using UnityEngine;

public class PointAndClick_1 : MonoBehaviour
{
    Vector3 source;
    Vector3 target;
    float speed;
    float distanceToTarget;
    const float DECELERATION_FACTOR = 0.6f;
    void FixedUpdate()
    {
        source = transform.position;
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
            }
        }
        this.transform.position = FollowPoint(source, target);
    }
 
    private Vector3 FollowPoint(Vector3 source, Vector3 target)
    {
        distanceToTarget = Vector3.Distance(source, target);
        speed = distanceToTarget / DECELERATION_FACTOR;
        return Vector3.MoveTowards(source, target, Time.deltaTime * speed);
    }
}
