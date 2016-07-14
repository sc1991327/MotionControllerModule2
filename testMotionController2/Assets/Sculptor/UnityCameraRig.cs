using UnityEngine;
using System.Collections;

public class UnityCameraRig : ICameraRig {

    public IPosAnchor CreatePosAnchor()
    {
        return new UnityPosAnchor();
    }

    public bool ConnectHandle()
    {
        return false;
    }

    public string GetInfo()
    {
        string temp = "Use The Unity CameraRig Now!";
        return temp;
    }

    public VRPlatform GetPlatform()
    {
        return VRPlatform.Unity;
    }
}
