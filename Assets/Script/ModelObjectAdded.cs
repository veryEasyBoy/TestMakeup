using System.Collections.Generic;
using UnityEngine;

public class ModelObjectAdded
{
    public RectTransform addTarget;
    public RectTransform handRectTransform;
    public List<Vector3> previousPosition = new List<Vector3>();
    public RectTransform thisRectTransform;
    public Vector3 defaultPosition;
    public ModelObjectAdded(RectTransform addTarget, RectTransform handRectTransform, List<Vector3> previousPosition, RectTransform thisRectTransform, Vector3 defaultPosition)
    {
        this.addTarget = addTarget;
        this.handRectTransform = handRectTransform;
        this.previousPosition = previousPosition;
        this.thisRectTransform = thisRectTransform;
        this.defaultPosition = defaultPosition;
    }
}
