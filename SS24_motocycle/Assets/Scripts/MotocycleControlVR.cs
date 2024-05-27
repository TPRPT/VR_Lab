using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.Vive;
using Unity.VisualScripting;
using UnityEngine;

public class MotorcycleControlVR : MonoBehaviour
{
    public HandRole rightHand = HandRole.RightHand;
    public HandRole leftHand = HandRole.LeftHand;
    public ControllerButton button = ControllerButton.Trigger;
    public Transform[] hands;
    public Transform pivot;
    

    public float GetAceleration()
    {
        // return ViveInput.GetAxis(rightHand, axis);

        if(Input.GetKey(KeyCode.O))
            return 1;
        else if(Input.GetKey(KeyCode.P))
            return -1;
        else
            return 0;
    }

    /// Going to right or left. Right is 1, left is -1
    public float GetSteering()
    {
        //Calculate line between two hands
        Vector3 diference = hands[1].position - hands[0].position;
        //Remove vertical component
        Vector3 projected = Vector3.ProjectOnPlane(diference, pivot.up);
        //How much right or left component do we have
        float dot = Vector3.Dot(projected.normalized, pivot.forward);

        //Flip
        return -dot;
    }

    // DEBUG. Visualize lines in editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(hands[0].position, hands[1].position);

        Vector3 diference = hands[1].position - hands[0].position;
        Vector3 projected = Vector3.ProjectOnPlane(diference, pivot.up);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(hands[0].position, hands[0].position + projected);

        float dot = Vector3.Dot(projected.normalized, pivot.forward);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pivot.position, pivot.position + dot * pivot.forward);

    }
}