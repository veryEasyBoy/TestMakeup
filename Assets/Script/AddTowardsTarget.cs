using DG.Tweening;
using UnityEngine;

public class AddTowardsTarget : TweenRectTransformDecorator
{
    protected RectTransform addTarget;
    protected RectTransform handRectTransform;
    public AddTowardsTarget(TweenRectTransformComponent component, RectTransform handRectTransform,RectTransform addTarget) : base(component)
    {
        this.addTarget = addTarget;
        this.handRectTransform = handRectTransform;
    }
    public override Tween GetTweenRectTransform(RectTransform target, float duration)
    {
        return component.GetTweenRectTransform(target, duration).OnStepComplete(() => SetPosition(target)).OnStepComplete(() =>component.GetTweenRectTransform(addTarget, duration));
    }
    private void SetPosition(RectTransform target)
    {
        Debug.Log("SetPos");
        target.position = handRectTransform.position;
        target.SetParent(handRectTransform);
    }
}
