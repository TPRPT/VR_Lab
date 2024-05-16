using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // waypoint
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform == player)
        {
            // accident
        }
    }
}
