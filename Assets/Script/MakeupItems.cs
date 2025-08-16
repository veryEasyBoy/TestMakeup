using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MakeupItems : MonoBehaviour
{
    [Header("An object to move towards")]
    [SerializeField] protected Transform targetTowards;
    [SerializeField] protected float duration;
    [Header("Main parent object")]
    [SerializeField] protected Transform parentTransform;

    [SerializeField] protected List<Vector3> previousPositions = new List<Vector3>();
    public int NumberOfVectors => previousPositions.Count;
    protected Transform handRectTransform;
    protected Vector3 defaultPosition;
    protected MakeupItemActivityController makeupActivityController;

    private void Awake()
    {
        makeupActivityController = FindFirstObjectByType<MakeupItemActivityController>();
        handRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
        defaultPosition = handRectTransform.position;
    }

    public virtual void TakeItem()
    {
        makeupActivityController.DeactiveLipstick();
        makeupActivityController.DeactiveShadow();
        HandChangesPosition(transform).
            OnKill(() =>
            {
                HandChangesPosition(targetTowards);
                SafePosition();
                ChangesParent(handRectTransform);
            });
    }

    protected void ChangesParent(Transform parent)
    {
        transform.SetParent(parent);
    }

    protected void SafePosition() => previousPositions.Add(handRectTransform.position);

    protected void RemoveLastPosition() => previousPositions.Remove(previousPositions.Last());

    public Tween TweenReturnOfPositions()
    {
        if (previousPositions.Count > 0)
        {
            return HandChangesPosition(previousPositions.Last()).OnKill(() =>
            {
                RemoveLastPosition();
                TweenReturnOfPositions();
            });
        }
        else
        {
            ChangesParent(parentTransform);
            return HandChangesPosition(defaultPosition);
        }
    }

    #region Options HandChangesPosition
    protected Tween HandChangesPosition(Transform target)
    {
        return handRectTransform.DOMove(target.position, duration).SetEase(Ease.Linear);
    }
    protected Tween HandChangesPosition(Transform target, float duration)
    {
        return handRectTransform.DOMove(target.position, duration).SetEase(Ease.Linear);
    }
    protected Tween HandChangesPosition(Vector3 target)
    {
        return handRectTransform.DOMove(target, duration).SetEase(Ease.Linear);
    }
    protected Tween HandChangesPosition(Vector3 target, float duration)
    {
        return handRectTransform.DOMove(target, duration).SetEase(Ease.Linear);
    }
    #endregion
}