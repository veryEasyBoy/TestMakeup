using DG.Tweening;
using UnityEngine;

public class HandTowardsObject : MonoBehaviour
{
    [Header("Hand")]
    [SerializeField] protected RectTransform hand;
    [Header("Target for towards")]
    [SerializeField] protected RectTransform target;
    [Header("Time to achieve the goal")]
    [SerializeField] protected float duration;

    // Движение руки к объекту
    public void MovingTowards()
    {
        hand.DOMove(target.transform.position, duration).SetEase(Ease.Linear);
    }
}
