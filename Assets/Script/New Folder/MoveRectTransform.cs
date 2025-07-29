using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveRectTransform : ICommand
{
    private RectTransform addTarget;
    private RectTransform hand;
    private float duration;
    private List<Vector3> previousPosition = new List<Vector3>();
    public MoveRectTransform(RectTransform hand, RectTransform addTarget, float duration)
    {
        this.addTarget = addTarget;
        this.hand = hand;
        this.duration = duration;
    }
    public Tween Execute(float duration)
    {
        previousPosition.Add(hand.position);
        return hand.DOMove(addTarget.transform.position, duration).SetEase(Ease.Linear);
    }
    public void Undo(float duration)
    {
        Vector3 pre = previousPosition.Last();
        hand.DOMove(pre, duration).SetEase(Ease.Linear);
        previousPosition.Remove(pre);
    }
}
