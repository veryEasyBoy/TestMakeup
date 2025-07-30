using DG.Tweening;
using UnityEngine;

public class BaseMoveTowards : MonoBehaviour
{
    [SerializeField] protected float duration;
    public virtual Tween GetTweenRectTransform(RectTransform objectForChangePosition,RectTransform target, float duration)
    {
        return objectForChangePosition.DOMove(target.transform.position, duration).SetEase(Ease.Linear);
    }
}
