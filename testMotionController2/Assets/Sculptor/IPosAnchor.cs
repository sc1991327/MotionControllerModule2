using UnityEngine;
using System.Collections;

public abstract class IPosAnchor
{
    public abstract Transform CameraPos { set; get; }
    public abstract Transform LeftHandPos { set; get; }
    public abstract Transform RightHandPos { set; get; }

    public abstract void Update();

}