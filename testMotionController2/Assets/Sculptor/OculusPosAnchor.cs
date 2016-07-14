using UnityEngine;
using System.Collections;
using UnityEditor;

public class OculusPosAnchor : IPosAnchor
{
    GameObject VRCameraRig;
    GameObject OculusCameraRig;

    GameObject OculusMainCameraObj;

    public override Transform CameraPos { set; get; }
    public override Transform LeftHandPos { set; get; }
    public override Transform RightHandPos { set; get; }

    public OculusPosAnchor()
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Sculptor/OculusCameraRig.prefab", typeof(GameObject));
        OculusCameraRig = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (OculusCameraRig == null)
        {
            Debug.LogError("Can't Find Oculus Camera Profab!");
        }

        OculusMainCameraObj = GameObject.FindWithTag("CameraRigOrg");
        if (OculusMainCameraObj == null)
        {
            Debug.LogError("Can't Find the CameraRigOrg tag Objects!");
        }

        VRCameraRig = GameObject.FindWithTag("VRCameraRig");
        if (VRCameraRig == null)
        {
            Debug.LogError("Can't Find the VRCameraRig tag Objects!");
        }

        OculusCameraRig.transform.parent = VRCameraRig.transform;
        OculusCameraRig.transform.localPosition = Vector3.zero;
        OculusCameraRig.transform.localRotation = Quaternion.identity;
    }

    public override void Update()
    {
        CameraPos = OculusMainCameraObj.transform.GetChild(1);
        LeftHandPos = OculusMainCameraObj.transform.GetChild(4);
        RightHandPos = OculusMainCameraObj.transform.GetChild(5);

        VRCameraRig.transform.GetChild(0).localPosition = CameraPos.localPosition;
        VRCameraRig.transform.GetChild(0).localRotation = CameraPos.localRotation;

        VRCameraRig.transform.GetChild(1).localPosition = LeftHandPos.localPosition;
        VRCameraRig.transform.GetChild(1).localRotation = LeftHandPos.localRotation;

        VRCameraRig.transform.GetChild(2).localPosition = RightHandPos.localPosition;
        VRCameraRig.transform.GetChild(2).localRotation = RightHandPos.localRotation;
    }

}
