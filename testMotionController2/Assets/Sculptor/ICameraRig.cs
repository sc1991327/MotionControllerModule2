using UnityEngine;
using System.Collections;

interface ICameraRig
{
    IPosAnchor CreatePosAnchor();

    bool ConnectHandle();

    VRPlatform GetPlatform();
    string GetInfo();
}

