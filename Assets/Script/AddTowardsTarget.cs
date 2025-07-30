using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddTowardsTarget : BaseMoveTowards, ICommand
{
    private ModelObjectAdded model;
    public AddTowardsTarget(ModelObjectAdded model)
    {
        this.model = model;
    }
    // Выполняет перемещение к начальному таргету, затем к добавленному
    public void Execute(float duration)
    {
        AddVector3();
        GetTweenRectTransform(model.handRectTransform, model.thisRectTransform, duration).OnStepComplete(() => GetPositionHand(model.thisRectTransform)).OnComplete(() => StartTweenMoveTowardsTransformAddedTarget(duration));
    }
    // Возвращает прошлую позицию hand
    public void Undo(float duration)
    {
        Vector3 pre = model.previousPosition.Last();
        RollBackTransformPosition(model.handRectTransform, pre, duration).OnComplete(() => SetDefaultPosition()).OnPlay(() => Undo(duration));
    }
    // Сохрвняет Vector3 в List
    private void AddVector3()
    {
        model.previousPosition.Add(model.handRectTransform.position);
    }
    private Tween RollBackTransformPosition(RectTransform hand, Vector3 vector,float duration)
    {
        return HandDefaultPosition(hand,vector,duration).OnStepComplete(() => RemoveVector(vector));
    }
    // Получает позицию hand и следует за ней
    private void GetPositionHand(RectTransform target)
    {
        target.position = model.handRectTransform.position;
        target.SetParent(model.handRectTransform);
    }
    // Устанавливает взятому объекту его изначальную позицию
    private void SetDefaultPosition()
    {
        if (model.thisRectTransform.parent != GameObject.FindGameObjectWithTag("Shelf").transform)
        {
            model.thisRectTransform.SetParent(GameObject.FindGameObjectWithTag("Shelf").transform);
            model.thisRectTransform.position = model.handRectTransform.position;
        }
    }
    private Tween HandDefaultPosition(RectTransform hand,Vector3 defaultPosition, float duration)
    {
        return hand.DOMove(defaultPosition, duration).SetEase(Ease.Linear);
    }
    // Удаляет Vector3 из списка
    private Vector3 RemoveVector(Vector3 vector)
    {
        model.previousPosition.Remove(vector);
        return vector;
    }
    // Начинает движение к добавленному таргету
    private Tween StartTweenMoveTowardsTransformAddedTarget(float duration)
    {
        return GetTweenRectTransform(model.handRectTransform, model.addTarget, duration).OnPlay(() => AddVector3());
    }
}
