using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Action Defination

public class InputMap {

    private List<ActionBase> actionList = new List<ActionBase>();
    private List<Axis2DBase> axis2DList = new List<Axis2DBase>();

    public void Add(ActionBase action)
    {
        actionList.Add(action);
    }

    public void Add(Axis2DBase axis2D)
    {
        axis2DList.Add(axis2D);
    }

    public void Remove(ActionBase action)
    {
        actionList.Remove(action);
    }

    public void Remove(Axis2DBase axis2D)
    {
        axis2DList.Remove(axis2D);
    }
	
	public void Update(VRPlatform pID) {

        switch (pID)
        {
            case VRPlatform.Oculus:
                OculusUpdate();
                break;
            case VRPlatform.Steam:
                SteamUpdate();
                break;
        }

    }

    public void SteamUpdate()
    {
        foreach (ActionBase action in actionList)
        {
            action.Update_Steam();
        }

        foreach (Axis2DBase axis2d in axis2DList)
        {
            axis2d.Update_Steam();
        }
    }

    public void OculusUpdate()
    {
        foreach (ActionBase action in actionList)
        {
            action.Update_Oculus();
        }

        foreach (Axis2DBase axis2d in axis2DList)
        {
            axis2d.Update_Oculus();
        }
    }
}

public class CommonButton
{
    public bool Press;
    public bool Down;
    public bool Up;

    public CommonButton()
    {
        Press = false;
        Down = false;
        Up = false;
    }
}

public class ActionBase
{
    public CommonButton cButton;

    public virtual void Update_Steam()
    {

    }
    public virtual void Update_Oculus()
    {

    }

}

public class Axis1DBase
{
    public float cAxis1D;

    public virtual void Update_Steam()
    {

    }
    public virtual void Update_Oculus()
    {

    }

}

public class Axis2DBase
{
    public Vector2 cAxis2D;

    public virtual void Update_Steam()
    {

    }
    public virtual void Update_Oculus()
    {

    }

}

/// <summary>
/// Customize Actions Definication
/// </summary>

public class Action_Menu_Left : ActionBase
{
    // Singleton

    public static Action_Menu_Left cInstance = new Action_Menu_Left();
    private Action_Menu_Left() { cButton = new CommonButton(); }

    // Interface

    public override void Update_Steam()
    {
        cButton.Press = SVRInput.GetPress(SVRInput.Button.L_Menu);
        cButton.Down = SVRInput.GetPressDown(SVRInput.Button.L_Menu);
        cButton.Up = SVRInput.GetPressUp(SVRInput.Button.L_Menu);
    }

    public override void Update_Oculus()
    {
        cButton.Press = OVRInput.Get(OVRInput.RawButton.A);
        cButton.Down = OVRInput.GetDown(OVRInput.RawButton.A);
        cButton.Up = OVRInput.GetUp(OVRInput.RawButton.A);
    }

}

public class Action_Menu_Right : ActionBase
{
    // Singleton

    public static Action_Menu_Right cInstance = new Action_Menu_Right();
    private Action_Menu_Right() { cButton = new CommonButton(); }

    // Interface

    public override void Update_Steam()
    {
        cButton.Press = SVRInput.GetPress(SVRInput.Button.R_Menu);
        cButton.Down = SVRInput.GetPressDown(SVRInput.Button.R_Menu);
        cButton.Up = SVRInput.GetPressUp(SVRInput.Button.R_Menu);
    }

    public override void Update_Oculus()
    {
        cButton.Press = OVRInput.Get(OVRInput.RawButton.X);
        cButton.Down = OVRInput.GetDown(OVRInput.RawButton.X);
        cButton.Up = OVRInput.GetUp(OVRInput.RawButton.X);
    }

}

public class Action_Trigger_Left : ActionBase
{
    // Singleton

    public static Action_Trigger_Left cInstance = new Action_Trigger_Left();
    private Action_Trigger_Left() { cButton = new CommonButton(); }

    // Interface

    public override void Update_Steam()
    {
        cButton.Press = SVRInput.GetPress(SVRInput.Button.L_Trigger);
        cButton.Down = SVRInput.GetPressDown(SVRInput.Button.L_Trigger);
        cButton.Up = SVRInput.GetPressUp(SVRInput.Button.L_Trigger);
    }

    public override void Update_Oculus()
    {
        cButton.Press = OVRInput.Get(OVRInput.RawButton.LIndexTrigger);
        cButton.Down = OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger);
        cButton.Up = OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger);
    }

}

public class Action_Trigger_Right : ActionBase
{
    // Singleton

    public static Action_Trigger_Right cInstance = new Action_Trigger_Right();
    private Action_Trigger_Right(){ cButton = new CommonButton(); }

    // Interface

    public override void Update_Steam()
    {
        cButton.Press = SVRInput.GetPress(SVRInput.Button.R_Trigger);
        cButton.Down = SVRInput.GetPressDown(SVRInput.Button.R_Trigger);
        cButton.Up = SVRInput.GetPressUp(SVRInput.Button.R_Trigger);
    }

    public override void Update_Oculus()
    {
        cButton.Press = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);
        cButton.Down = OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger);
        cButton.Up = OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger);
    }


}

public class Action_Grip_Left : ActionBase
{
    public static Action_Grip_Left cInstance = new Action_Grip_Left();
    private Action_Grip_Left() { cButton = new CommonButton(); }

    public override void Update_Steam()
    {
        cButton.Press = SVRInput.GetPress(SVRInput.Button.L_Grip);
        cButton.Down = SVRInput.GetPressDown(SVRInput.Button.L_Grip);
        cButton.Up = SVRInput.GetPressUp(SVRInput.Button.L_Grip);
    }

    public override void Update_Oculus()
    {
        cButton.Press = OVRInput.Get(OVRInput.RawButton.LHandTrigger);
        cButton.Down = OVRInput.GetDown(OVRInput.RawButton.LHandTrigger);
        cButton.Up = OVRInput.GetUp(OVRInput.RawButton.LHandTrigger);
    }

}

public class Action_Grip_Right : ActionBase
{
    public static Action_Grip_Right cInstance = new Action_Grip_Right();
    private Action_Grip_Right() { cButton = new CommonButton(); }

    public override void Update_Steam()
    {
        cButton.Press = SVRInput.GetPress(SVRInput.Button.R_Grip);
        cButton.Down = SVRInput.GetPressDown(SVRInput.Button.R_Grip);
        cButton.Up = SVRInput.GetPressUp(SVRInput.Button.R_Grip);
    }

    public override void Update_Oculus()
    {
        cButton.Press = OVRInput.Get(OVRInput.RawButton.RHandTrigger);
        cButton.Down = OVRInput.GetDown(OVRInput.RawButton.RHandTrigger);
        cButton.Up = OVRInput.GetUp(OVRInput.RawButton.RHandTrigger);
    }

}

public class Axis2D_Main_Left : Axis2DBase
{
    public static Axis2D_Main_Left cInstance = new Axis2D_Main_Left();
    private Axis2D_Main_Left() { cAxis2D = Vector2.zero; }

    public override void Update_Steam()
    {
        cAxis2D = SVRInput.GetAxis2D(SVRInput.Axis2D.L_TouchPos);
    }

    public override void Update_Oculus()
    {
        cAxis2D = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
    }

}

public class Axis2D_Main_Right : Axis2DBase
{
    public static Axis2D_Main_Right cInstance = new Axis2D_Main_Right();
    private Axis2D_Main_Right() { cAxis2D = Vector2.zero; }

    public override void Update_Steam()
    {
        cAxis2D = SVRInput.GetAxis2D(SVRInput.Axis2D.R_TouchPos);
    }

    public override void Update_Oculus()
    {
        cAxis2D = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
    }
}


