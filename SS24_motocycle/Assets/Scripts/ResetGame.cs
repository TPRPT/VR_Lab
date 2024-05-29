using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.Vive;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Menu) || ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Menu))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }   
}
