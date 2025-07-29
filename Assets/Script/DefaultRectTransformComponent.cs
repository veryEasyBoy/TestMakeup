using DG.Tweening;
using UnityEngine;

public class DefaultRectTransformComponent : TweenRectTransformComponent
{
    protected RectTransform rectTransform;
    public DefaultRectTransformComponent(RectTransform rectTransform)
    {   
        this.rectTransform = rectTransform;
    }
    public override Tween GetTweenRectTransform(RectTransform target, float duration)
    {
        return rectTransform.DOMove(target.transform.position, duration).SetEase(Ease.Linear);
    }
}
