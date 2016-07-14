using UnityEngine;
using System.Collections;

public class ActionManage : MonoBehaviour {

    InputMap actions = new InputMap();

	// Use this for initialization
	void Start () {

        actions.Add(Action_Menu_Left.cInstance);
        actions.Add(Action_Grip_Left.cInstance);
        actions.Add(Action_Trigger_Left.cInstance);

        actions.Add(Action_Menu_Right.cInstance);
        actions.Add(Action_Grip_Right.cInstance);
        actions.Add(Action_Trigger_Right.cInstance);

        actions.Add(Axis2D_Main_Left.cInstance);
        actions.Add(Axis2D_Main_Right.cInstance);

	}
	
	// Update is called once per frame
	void Update () {

        actions.Update(VRCameraRig.vrPlatform);

    }
}
