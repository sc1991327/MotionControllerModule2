using UnityEngine;
using System.Collections;
using UnityEditor;

public class SteamPosAnchor : IPosAnchor
{
    GameObject VRCameraRig;
    GameObject SteamCameraRig;

    GameObject SteamMainCameraObj;

    public override Transform CameraPos { set; get; }
    public override Transform LeftHandPos { set; get; }
    public override Transform RightHandPos { set; get; }

    public SteamPosAnchor()
    {

        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Sculptor/SteamCameraRig.prefab", typeof(GameObject));
        SteamCameraRig = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (SteamCameraRig == null)
        {
            Debug.LogError("Can't Find Steam Camera Profab!");
        }

        SteamMainCameraObj = GameObject.FindWithTag("CameraRigOrg");
        if (SteamMainCameraObj == null)
        {
            Debug.LogError("Can't Find the CameraRigOrg tag Objects!");
        }

        VRCameraRig = GameObject.FindWithTag("VRCameraRig");
        if (VRCameraRig == null)
        {
            Debug.LogError("Can't Find the VRCameraRig tag Objects!");
        }

        SteamCameraRig.transform.parent = VRCameraRig.transform;
        SteamCameraRig.transform.localPosition = Vector3.zero;
        SteamCameraRig.transform.localRotation = Quaternion.identity;
    }

    public override void Update()
    {
        CameraPos = SteamMainCameraObj.transform.GetChild(2);
        LeftHandPos = SteamMainCameraObj.transform.GetChild(0);
        RightHandPos = SteamMainCameraObj.transform.GetChild(1);

        VRCameraRig.transform.GetChild(0).localPosition = CameraPos.localPosition;
        VRCameraRig.transform.GetChild(0).localRotation = CameraPos.localRotation;

        VRCameraRig.transform.GetChild(1).localPosition = LeftHandPos.localPosition;
        VRCameraRig.transform.GetChild(1).localRotation = LeftHandPos.localRotation;

        VRCameraRig.transform.GetChild(2).localPosition = RightHandPos.localPosition;
        VRCameraRig.transform.GetChild(2).localRotation = RightHandPos.localRotation;
    }
}
