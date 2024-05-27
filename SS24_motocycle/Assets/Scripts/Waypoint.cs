using UnityEngine;

public class Waypoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameObject.Find("Waypoints").GetComponent<WaypointNew>().OnTrigger();
    }
}
