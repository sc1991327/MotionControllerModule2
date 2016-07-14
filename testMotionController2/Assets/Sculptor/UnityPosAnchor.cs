using UnityEngine;
using System.Collections;
using UnityEditor;

public class UnityPosAnchor : IPosAnchor
{
    GameObject VRCameraRig;
    GameObject UnityCameraRig;

    GameObject UnityMainCameraObj;

    public override Transform CameraPos { set; get; }
    public override Transform LeftHandPos { set; get; }
    public override Transform RightHandPos { set; get; }

    public UnityPosAnchor()
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Sculptor/UnityCameraRig.prefab", typeof(GameObject));
        UnityCameraRig = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (UnityCameraRig == null)
        {
            Debug.LogError("Can't Find Oculus Camera Profab!");
        }

        UnityMainCameraObj = GameObject.FindWithTag("CameraRigOrg");
        if (UnityMainCameraObj == null)
        {
            Debug.LogError("Can't Find Unity Main Camera Objects!");
        }

        VRCameraRig = GameObject.FindWithTag("VRCameraRig");
        if (VRCameraRig == null)
        {
            Debug.LogError("Can't Find the VRCameraRig tag Objects!");
        }

        UnityCameraRig.transform.parent = VRCameraRig.transform;
        UnityCameraRig.transform.localPosition = Vector3.zero;
        UnityCameraRig.transform.localRotation = Quaternion.identity;
    }

    public override void Update()
    {
        CameraPos = UnityMainCameraObj.transform;

        VRCameraRig.transform.GetChild(0).localPosition = CameraPos.localPosition;
        VRCameraRig.transform.GetChild(0).localRotation = CameraPos.localRotation;
    }
}
