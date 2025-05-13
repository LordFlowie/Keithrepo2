using UnityEngine;

public class WaypointManager_1 : MonoBehaviour
{
    public GameObject[] waypoints;
    private int nextIndex;

    public GameObject NextWaypoint(GameObject current)
    {
        // Check if waypoints exist
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("WaypointManager_1: No waypoints assigned!");
            return null;
        }

        
        int currentIndex = System.Array.IndexOf(waypoints, current);
        nextIndex = (currentIndex >= 0) ? (currentIndex + 1) % waypoints.Length : 0;

        return waypoints[nextIndex];
    }
}


