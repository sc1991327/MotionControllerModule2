using UnityEngine;
using System.Collections;

public class testAction : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Action_Grip_Left.cInstance.cButton.Press)
        {
            Debug.Log("Handle Conection: " + VRCameraRig.connectHandle);
            Debug.Log("Test Action: " + Axis2D_Main_Left.cInstance.cAxis2D);
        }
    }
}
