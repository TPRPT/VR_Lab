using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject carPrefab;
    public Transform spawnPoint;
    public Transform player;

    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime; // Increment timer

        if (counter >= spawnRate)
        {
            counter = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        Transform position = spawnPoint;
        GameObject car = GameObject.Instantiate(carPrefab, position.position, position.rotation);
        TrafficMovement movement = car.GetComponent<TrafficMovement>();
        movement.player = player;
    }
}
