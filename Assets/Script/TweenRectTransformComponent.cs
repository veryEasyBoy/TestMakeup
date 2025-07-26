using DG.Tweening;
using UnityEngine;

public abstract class TweenRectTransformComponent
{
    public abstract Tween GetTweenRectTransform(RectTransform target, float duration);
}
