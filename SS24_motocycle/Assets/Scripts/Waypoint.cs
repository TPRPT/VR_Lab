using UnityEngine;

public class Waypoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
<<<<<<< HEAD
        GameObject.Find("Waypoints").GetComponent<WaypointNew>().OnTrigger();
=======
        GameObject.Find("Waypoints").GetComponent<WaypointManager>().OnTrigger();
>>>>>>> 82d24ce08c83b0e707b8f496fdd21b79cf9c1c69
    }
}
