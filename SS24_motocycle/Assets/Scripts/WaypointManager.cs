using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WaypointManager : MonoBehaviour
{
    public GameObject prefabWP, currentWP, prefabMP, mapPoint, parentWP;
    public Transform[] waypoints;
    public Transform position;
    

    // UI
    public Button GameStart;
    public TMP_Text timer;
    public float currentTime = 60;

    public TMP_Text point;
    public float score = 0;



    // Start is called before the first frame update
    void Start()
    {
        SetWaypoint();
        GameObject.Find("Canvas").GetComponent<MainCanvas>().centerText = "Start!";
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Point();
    }

    public void OnTrigger()
    {
        PlusPoint();
        SetWaypoint();
    }

    void SetWaypoint()
    {
        if (currentWP == null)
        {
            position = waypoints[UnityEngine.Random.Range(0, waypoints.Length)];
        }
        else // prevent duplication
        {
            List<Transform> newWPs = waypoints.ToList();
            newWPs.Remove(position);
            position = newWPs[UnityEngine.Random.Range(0, newWPs.Count)];
        }

        currentWP = Instantiate(prefabWP, position.position, position.rotation);
        mapPoint = Instantiate(prefabMP, position.position + new Vector3(0,35,0), position.rotation);

        currentWP.transform.parent = parentWP.transform;
        mapPoint.transform.parent = currentWP.transform;
    }

    void Timer()
    {
        currentTime -= Time.deltaTime;
        timer.text = "Time: " + currentTime.ToString("F0");

        if (currentTime <= 0)
        {
            timer.text = "Time Over";
            TimeOver();
        }
    }

    void Point()
    {
        point.text = "Score: " + score.ToString();
    }

    void PlusPoint()
    {
        score++;
        GameObject.Find("Canvas").GetComponent<MainCanvas>().centerText = "Good!";
    }

    void TimeOver()
    {
        point.text = null;
        Destroy(currentWP);

        GameObject.Find("Canvas").GetComponent<MainCanvas>().centerText = "Finish!\nTotal Score: "+ score.ToString();
    }
}
