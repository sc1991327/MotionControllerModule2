using UnityEngine;
using System.Collections;
using Valve.VR;
using UnityEngine.VR;
using System.Collections.Generic;

public class SteamCameraRig : ICameraRig
{
    public IPosAnchor CreatePosAnchor()
    {
        return new SteamPosAnchor();
    }

    public bool ConnectHandle()
    {
        return HasLeftHandle() || HasRightHandle();
    }

    public bool HasLeftHandle()
    {
        return SVRInput.HasLeftHandle();
    }

    public bool HasRightHandle()
    {
        return SVRInput.HasRightHandle();
    }

    public string GetInfo()
    {
        string temp = "Use The Steam CameraRig Now!";
        return temp;
    }

    public VRPlatform GetPlatform()
    {
        return VRPlatform.Steam;
    }
}

