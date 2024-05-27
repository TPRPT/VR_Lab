using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WaypointNew : MonoBehaviour
{
    public GameObject prefabWP, currentWP, prefabMP, mapPoint, parentWP;
    public Transform[] waypoints;
    public Transform position;
    public Boolean finish;
    public float finishTime;
    public float delivery = 3;
    

    // UI
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
    }

    void SetWaypoint()
    {
        List<Transform> newWPs = waypoints.ToList();

        for (int i=0; i < delivery ; i++)
        {   
            newWPs.Remove(position);
            position = newWPs[UnityEngine.Random.Range(0, newWPs.Count)];

            currentWP = Instantiate(prefabWP, position.position, position.rotation);
            mapPoint = Instantiate(prefabMP, position.position + new Vector3(0,80,0), position.rotation);

            currentWP.transform.parent = parentWP.transform;
            mapPoint.transform.parent = currentWP.transform;
        }
    }

    void Timer()
    {
        if (finish == false)
        {
            currentTime -= Time.deltaTime;
            timer.text = "Time: " + currentTime.ToString("F0");

            if (currentTime <= 0)
            {
                timer.text = "Time Over";
                TimeOver();
            }
        } else {
            timer.text = "Time: " + (60 - finishTime).ToString("F0");
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
        if(score == delivery) Finish();
    }

    void TimeOver()
    {
        point.text = null;
        Destroy(parentWP);

        GameObject.Find("Canvas").GetComponent<MainCanvas>().centerText = "Game Over!\nTotal Score: "+ score.ToString()+"/"+ delivery;
    }

    void Finish()
    {
        finish = true;
        finishTime = 60 - currentTime;
        GameObject.Find("Canvas").GetComponent<MainCanvas>().centerText = "Finish! The delivery was successful\n"+ score.ToString() +" pizzas in "+ finishTime.ToString("F0") +" seconds";
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
