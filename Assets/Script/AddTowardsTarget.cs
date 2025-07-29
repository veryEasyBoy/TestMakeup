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
    // Выполняет перемещение к начальному таргету, затем к добавленному
    public Tween Execute(float duration)
    {
        AddVector3();
        return GetTweenRectTransform(thisRect, duration);
    }
    // Возвращает прошлую позицию hand
    public void Undo(float duration)
    {
        Vector3 pre = previousPosition.Last();
        RollBackTransformPosition(pre, duration).OnComplete(() => SetDefaultPosition()).OnPlay(() => Undo(duration));
    }
    // Сохрвняет Vector3 в List
    private void AddVector3()
    {
        previousPosition.Add(handRectTransform.position);
    }
    private Tween RollBackTransformPosition(Vector3 vector,float duration)
    {
        return handRectTransform.DOMove(vector, duration).SetEase(Ease.Linear).OnStepComplete(() => RemoveVector(vector));
    }
    // Получает позицию hand и следует за ней
    private void GetPositionHand(RectTransform target)
    {
        defaultPosition = target.position;
        target.position = handRectTransform.position;
        target.SetParent(handRectTransform);
    }
    // Устанавливает взятому объекту его изначальную позицию
    private void SetDefaultPosition()
    {
        if (thisRect.parent != GameObject.FindGameObjectWithTag("Shelf").transform)
        {
            thisRect.SetParent(GameObject.FindGameObjectWithTag("Shelf").transform);
            thisRect.position = defaultPosition;
        }
    }
    // Удаляет Vector3 из списка
    private Vector3 RemoveVector(Vector3 vector)
    {
        previousPosition.Remove(vector);
        return vector;
    }
    // Начинает движение к добавленному таргету
    private Tween StartTweenMoveTowardsTransformAddedTarget(float duration)
    {
        return GetTweenRectTransform(addTarget, duration).OnPlay(() => AddVector3());
    }
}
