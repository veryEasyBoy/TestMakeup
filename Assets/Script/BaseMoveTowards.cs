using DG.Tweening;
using UnityEngine;

public class BaseMoveTowards : MonoBehaviour
{
    [SerializeField] protected float duration;
    protected RectTransform handTransform;
    public virtual Tween GetTweenRectTransform(RectTransform target, float duration)
    {
        return handTransform.DOMove(target.transform.position, duration).SetEase(Ease.Linear);
    }
}
