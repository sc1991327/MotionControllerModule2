using UnityEngine;
using System.Collections;

public class OculusCameraRig : ICameraRig
{
    public IPosAnchor CreatePosAnchor()
    {
        return new OculusPosAnchor();
    }

    public bool ConnectHandle()
    {
        return ((OVRInput.GetConnectedControllers() & OVRInput.Controller.Touch) != 0);
    }

    public string GetInfo()
    {
        string temp = "Use The Oculus CameraRig Now!";
        return temp;
    }

    public VRPlatform GetPlatform()
    {
        return VRPlatform.Oculus;
    }
}
