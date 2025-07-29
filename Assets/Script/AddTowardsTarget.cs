using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddTowardsTarget : BaseMoveTowards, ICommand
{
    private RectTransform addTarget;
    private RectTransform handRectTransform;
    private List<Vector3> previousPosition = new List<Vector3>();
    private RectTransform thisRect;
    private Vector3 defaultPosition;
    public AddTowardsTarget(TweenRectTransformComponent component, RectTransform handRectTransform, List<Vector3> previousPosition, RectTransform addTarget, RectTransform thisRect)
    {
        this.addTarget = addTarget;
        this.handRectTransform = handRectTransform;
        this.previousPosition = previousPosition;
        this.thisRect = thisRect;
    }
    // ��������� ����������� � ���������� �������, ����� � ������������
    public Tween Execute(float duration)
    {
        AddVector3();
        return GetTweenRectTransform(thisRect, duration);
    }
    // ���������� ������� ������� hand
    public void Undo(float duration)
    {
        Vector3 pre = previousPosition.Last();
        RollBackTransformPosition(pre, duration).OnComplete(() => SetDefaultPosition()).OnPlay(() => Undo(duration));
    }
    // ��������� Vector3 � List
    private void AddVector3()
    {
        previousPosition.Add(handRectTransform.position);
    }
    private Tween RollBackTransformPosition(Vector3 vector,float duration)
    {
        return handRectTransform.DOMove(vector, duration).SetEase(Ease.Linear).OnStepComplete(() => RemoveVector(vector));
    }
    // �������� ������� hand � ������� �� ���
    private void GetPositionHand(RectTransform target)
    {
        defaultPosition = target.position;
        target.position = handRectTransform.position;
        target.SetParent(handRectTransform);
    }
    // ������������� ������� ������� ��� ����������� �������
    private void SetDefaultPosition()
    {
        if (thisRect.parent != GameObject.FindGameObjectWithTag("Shelf").transform)
        {
            thisRect.SetParent(GameObject.FindGameObjectWithTag("Shelf").transform);
            thisRect.position = defaultPosition;
        }
    }
    // ������� Vector3 �� ������
    private Vector3 RemoveVector(Vector3 vector)
    {
        previousPosition.Remove(vector);
        return vector;
    }
    // �������� �������� � ������������ �������
    private Tween StartTweenMoveTowardsTransformAddedTarget(float duration)
    {
        return GetTweenRectTransform(addTarget, duration).OnPlay(() => AddVector3());
    }
}
