using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using System.Collections.Generic;
using Valve.VR;

public enum VRPlatform { None, Unity, Steam, Oculus}

public class VRCameraRig : MonoBehaviour {

    ICameraRig cameraRig;
    IPosAnchor posAnchor;

    public static VRPlatform vrPlatform;
    public static bool connectHandle;

    void Awake()
    {
        if (!UnityEngine.VR.VRSettings.enabled)
        {
            //this is to prevent a long lag on startup
            //if it's not enabled and the device is not set to none it can eat up 10+ seconds, not sure why
            UnityEngine.VR.VRSettings.loadedDevice = UnityEngine.VR.VRDeviceType.None;
        }

        if (!UnityEngine.VR.VRSettings.enabled || !UnityEngine.VR.VRDevice.isPresent || UnityEngine.VR.VRSettings.loadedDevice == VRDeviceType.None)
        {
            //try to enable steamvr then check the result
            SteamVR.enabled = true;
            if (SteamVR.enabled)
            {
                cameraRig = new SteamCameraRig();
            }
            else
            {
                cameraRig = new UnityCameraRig();
            }

        }
        else
        {
            cameraRig = new OculusCameraRig();
        }

        posAnchor = cameraRig.CreatePosAnchor();
        vrPlatform = cameraRig.GetPlatform();
        Debug.Log(cameraRig.GetInfo());
    }


    void Update()
    {
        connectHandle = cameraRig.ConnectHandle();
        posAnchor.Update();

        // Use Example
        //Debug.Log("CameraPos: " + posAnchor.CameraPos.position);
    }
}
