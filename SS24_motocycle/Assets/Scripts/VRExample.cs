using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.Vive;
using UnityEngine;

public class VRExample : MonoBehaviour
{
    public HandRole rightHand = HandRole.RightHand;
    public ControllerAxis axis = ControllerAxis.Trigger;
    // public ControllerButton button = ControllerButton.Trigger;

    public Transform[] hands;
    public Transform pivot;
    public Transform handle;

    public float GetAceleration()
    {
        return ViveInput.GetAxis(rightHand, axis);
        // if(ViveInput.GetPress(rightHand, button))
            // return 1;
        // else
            // return 0;
    }

    /// <summary>
    /// Going to right or left. Right is 1, left is -1
    /// </summary>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetSteering()
    {
        //Calculate line between two hands
        Vector3 diference = hands[1].position - hands[0].position;
        //Remove vertical component
        Vector3 projected = Vector3.ProjectOnPlane(diference, pivot.up);
        //How much right or left component do we have
        float dot = Vector3.Dot(projected.normalized, pivot.forward);

        //Update handle
        ChangeHandlePosition(-dot);
        //Flip
        return -dot;
    }

    void ChangeHandlePosition(float dot)
    {
        //Rotate handle
        handle.localRotation = Quaternion.Euler(0, dot*90, 0);
    }

    // DEBUG. Visualize lines in editor
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
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