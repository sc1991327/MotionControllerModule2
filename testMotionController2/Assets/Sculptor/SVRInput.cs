using UnityEngine;
using System.Collections;
using Valve.VR;
using System.Collections.Generic;

public class SButton
{
    public bool Down;
    public bool Hold;
    public bool Up;

    public SButton()
    {
        Down = false;
        Hold = false;
        Up = false;
    }

    public SButton(bool i_down, bool i_hold, bool i_up)
    {
        Down = i_down;
        Hold = i_hold;
        Up = i_up;
    }
}

public class SteamInputState
{
    public bool Handle_L;
    public bool Handle_R;

    public SButton Button_L_Trigger;
    public SButton Button_L_Grip;
    public SButton Button_L_Menu;
    public SButton Button_L_Touchpad;
    public SButton Button_R_Trigger;
    public SButton Button_R_Grip;
    public SButton Button_R_Menu;
    public SButton Button_R_Touchpad;

    public SButton Touch_L;
    public SButton Touch_R;

    public Vector2 Axis2D_L_Touch;
    public Vector2 Axis2D_R_Touch;

    public SteamInputState()
    {
        Button_L_Trigger = new SButton();
        Button_L_Grip = new SButton();
        Button_L_Menu = new SButton();
        Button_L_Touchpad = new SButton();
        Button_R_Trigger = new SButton();
        Button_R_Grip = new SButton();
        Button_R_Menu = new SButton();
        Button_R_Touchpad = new SButton();

        Touch_L = new SButton();
        Touch_R = new SButton();

        Axis2D_L_Touch = new Vector2();
        Axis2D_R_Touch = new Vector2();
    }
}

public enum HandleType { none, left, right }

public class SVRInput : MonoBehaviour
{

    public enum Button
    {
        None,
        L_Trigger,
        L_Grip,
        L_Menu,
        L_Touchpad,
        R_Trigger,
        R_Grip,
        R_Menu,
        R_Touchpad
    }

    public enum Touch
    {
        None,
        L_Touch,
        R_Touch
    }

    public enum Axis2D
    {
        None,
        L_TouchPos,
        R_TouchPos
    }

    public static bool hasHandleLeft = false;
    public static bool hasHandleRight = false;

    static SteamInputState svrInput;

    // cached roles - may or may not be connected
    public GameObject SteamLeftHandController;
    public GameObject SteamRightHandController;

    private SteamVR_TrackedObject leftTrackObj;
    private SteamVR_TrackedObject rightTrackObj;

    List<int> controllerIndices = new List<int>();

    // Use this for initialization
    void Awake()
    {
        leftTrackObj = SteamLeftHandController.GetComponent<SteamVR_TrackedObject>();
        rightTrackObj = SteamRightHandController.GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        svrInput = new SteamInputState();
    }

    private void OnDeviceConnected(params object[] args)
    {
        SteamDeviceConnected(args);
    }

    void OnEnable()
    {
        SteamVR_Utils.Event.Listen("device_connected", OnDeviceConnected);
    }

    void OnDisable()
    {
        SteamVR_Utils.Event.Remove("device_connected", OnDeviceConnected);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var index in controllerIndices)
        {
            var deviceHand = SteamVR_Controller.Input(index);

            if (index == (int)leftTrackObj.index)
            {
                //Debug.Log("Left Index: " + index);
                // leftHand

                hasHandleLeft = true;

                svrInput.Button_L_Trigger.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger);
                svrInput.Button_L_Trigger.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_SteamVR_Trigger);
                svrInput.Button_L_Trigger.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger);

                svrInput.Button_L_Grip.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_Grip);
                svrInput.Button_L_Grip.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_Grip);
                svrInput.Button_L_Grip.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_Grip);

                svrInput.Button_L_Menu.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_ApplicationMenu);
                svrInput.Button_L_Menu.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_ApplicationMenu);
                svrInput.Button_L_Menu.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_ApplicationMenu);

                svrInput.Button_L_Touchpad.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_Axis0);
                svrInput.Button_L_Touchpad.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_Axis0);
                svrInput.Button_L_Touchpad.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_Axis0);

                svrInput.Touch_L.Down = deviceHand.GetTouchDown(EVRButtonId.k_EButton_Axis0);
                svrInput.Touch_L.Hold = deviceHand.GetTouch(EVRButtonId.k_EButton_Axis0);
                svrInput.Touch_L.Up = deviceHand.GetTouchUp(EVRButtonId.k_EButton_Axis0);

                svrInput.Axis2D_L_Touch = deviceHand.GetAxis(EVRButtonId.k_EButton_Axis0);

            }
            else if (index == (int)rightTrackObj.index)
            {
                //Debug.Log("Right Index: " + index);
                // rightHand

                hasHandleRight = true;

                svrInput.Button_R_Trigger.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger);
                svrInput.Button_R_Trigger.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_SteamVR_Trigger);
                svrInput.Button_R_Trigger.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger);

                svrInput.Button_R_Grip.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_Grip);
                svrInput.Button_R_Grip.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_Grip);
                svrInput.Button_R_Grip.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_Grip);

                svrInput.Button_R_Menu.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_ApplicationMenu);
                svrInput.Button_R_Menu.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_ApplicationMenu);
                svrInput.Button_R_Menu.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_ApplicationMenu);

                svrInput.Button_R_Touchpad.Down = deviceHand.GetPressDown(EVRButtonId.k_EButton_Axis0);
                svrInput.Button_R_Touchpad.Hold = deviceHand.GetPress(EVRButtonId.k_EButton_Axis0);
                svrInput.Button_R_Touchpad.Up = deviceHand.GetPressUp(EVRButtonId.k_EButton_Axis0);

                svrInput.Touch_R.Down = deviceHand.GetTouchDown(EVRButtonId.k_EButton_Axis0);
                svrInput.Touch_R.Hold = deviceHand.GetTouch(EVRButtonId.k_EButton_Axis0);
                svrInput.Touch_R.Up = deviceHand.GetTouchUp(EVRButtonId.k_EButton_Axis0);

                svrInput.Axis2D_R_Touch = deviceHand.GetAxis(EVRButtonId.k_EButton_Axis0);
            }
            else
            {
                //Debug.Log("Input Index: " + index);
            }

            svrInput.Handle_L = hasHandleLeft;
            svrInput.Handle_R = hasHandleRight;
        }

    }

    private void SteamDeviceConnected(params object[] args)
    {
        var index = (int)args[0];

        var system = OpenVR.System;
        if (system == null || system.GetTrackedDeviceClass((uint)index) != ETrackedDeviceClass.Controller)
            return;

        var connected = (bool)args[1];
        if (connected)
        {
            Debug.Log(string.Format("Controller {0} connected.", index));
            controllerIndices.Add(index);
        }
        else
        {
            Debug.Log(string.Format("Controller {0} disconnected.", index));
            controllerIndices.Remove(index);
        }
    }

    public static bool HasLeftHandle()
    {
        return svrInput.Handle_L;
    }

    public static bool HasRightHandle()
    {
        return svrInput.Handle_R;
    }

    public static bool Get(Button virtualButton)
    {
        return GetPress(virtualButton);
    }

    public static Vector2 Get(Axis2D virtualAxis)
    {
        return GetAxis2D(virtualAxis);
    }

    public static bool GetPress(Button virtualButton)
    {
        bool revalue = false;

        switch (virtualButton)
        {
            case Button.L_Grip:
                revalue = svrInput.Button_L_Grip.Hold;
                break;
            case Button.L_Menu:
                revalue = svrInput.Button_L_Menu.Hold;
                break;
            case Button.L_Touchpad:
                revalue = svrInput.Button_L_Touchpad.Hold;
                break;
            case Button.L_Trigger:
                revalue = svrInput.Button_L_Trigger.Hold;
                break;
            case Button.R_Grip:
                revalue = svrInput.Button_R_Grip.Hold;
                break;
            case Button.R_Menu:
                revalue = svrInput.Button_R_Menu.Hold;
                break;
            case Button.R_Touchpad:
                revalue = svrInput.Button_R_Touchpad.Hold;
                break;
            case Button.R_Trigger:
                revalue = svrInput.Button_R_Trigger.Hold;
                break;
        }
        return revalue;
    }

    public static bool GetPressDown(Button virtualButton)
    {
        bool revalue = false;

        switch (virtualButton)
        {
            case Button.L_Grip:
                revalue = svrInput.Button_L_Grip.Down;
                break;
            case Button.L_Menu:
                revalue = svrInput.Button_L_Menu.Down;
                break;
            case Button.L_Touchpad:
                revalue = svrInput.Button_L_Touchpad.Down;
                break;
            case Button.L_Trigger:
                revalue = svrInput.Button_L_Trigger.Down;
                break;
            case Button.R_Grip:
                revalue = svrInput.Button_R_Grip.Down;
                break;
            case Button.R_Menu:
                revalue = svrInput.Button_R_Menu.Down;
                break;
            case Button.R_Touchpad:
                revalue = svrInput.Button_R_Touchpad.Down;
                break;
            case Button.R_Trigger:
                revalue = svrInput.Button_R_Trigger.Down;
                break;
        }
        return revalue;
    }

    public static bool GetPressUp(Button virtualButton)
    {
        bool revalue = false;

        switch (virtualButton)
        {
            case Button.L_Grip:
                revalue = svrInput.Button_L_Grip.Up;
                break;
            case Button.L_Menu:
                revalue = svrInput.Button_L_Menu.Up;
                break;
            case Button.L_Touchpad:
                revalue = svrInput.Button_L_Touchpad.Up;
                break;
            case Button.L_Trigger:
                revalue = svrInput.Button_L_Trigger.Up;
                break;
            case Button.R_Grip:
                revalue = svrInput.Button_R_Grip.Up;
                break;
            case Button.R_Menu:
                revalue = svrInput.Button_R_Menu.Up;
                break;
            case Button.R_Touchpad:
                revalue = svrInput.Button_R_Touchpad.Up;
                break;
            case Button.R_Trigger:
                revalue = svrInput.Button_R_Trigger.Up;
                break;
        }
        return revalue;
    }

    public static Vector2 GetAxis2D(Axis2D virtualAxis)
    {
        Vector2 revalue = new Vector2();

        switch (virtualAxis)
        {
            case Axis2D.L_TouchPos:
                revalue = svrInput.Axis2D_L_Touch;
                break;
            case Axis2D.R_TouchPos:
                revalue = svrInput.Axis2D_R_Touch;
                break;
        }

        return revalue;
    }
}
