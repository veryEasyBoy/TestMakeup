using DG.Tweening;
using UnityEngine;

public class TweenRectTransformDecorator : TweenRectTransformComponent
{
    protected TweenRectTransformComponent component;
    public TweenRectTransformDecorator(TweenRectTransformComponent component)
    {
        this.component = component;
    }
    public override Tween GetTweenRectTransform(RectTransform target, float duration)
    {
        return component.GetTweenRectTransform(target, duration);
    }
}
