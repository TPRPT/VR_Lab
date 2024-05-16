using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public TMP_Text center;
    public float time = 0;
    public String centerText;

    public void Update()
    {
        center.text = centerText;

        time += Time.deltaTime;

        if(time > 5) // Reset
        {
            time = 0;
            centerText = null;
        }

    }
}
