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
    protected Transform handRectTransform;
    protected Vector3 defaultPosition;
    protected FaceZone faceZone;

    private void Awake()
    {
        faceZone = GameObject.FindGameObjectWithTag("FaceZone").GetComponent<FaceZone>();
        handRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
        defaultPosition = handRectTransform.position;
    }

    public void TakeItem()
    {
        HandChangesPosition(transform).
            OnKill(() => { HandChangesPosition(targetTowards); SafePosition(); ChangesParent(handRectTransform); faceZone.ActivateToColliderZone(); });
    }

    protected void ChangesParent(Transform parent)
    {
        transform.SetParent(parent);
    }

    protected void SafePosition() => previousPositions.Add(handRectTransform.position);

    protected void RemoveLastPosition() => previousPositions.Remove(previousPositions.Last());

    public virtual Tween TweenReturnOfPositions()
    {
        if (previousPositions.Count > 0)
        {
            return HandChangesPosition(previousPositions.Last()).OnKill(() => { RemoveLastPosition(); TweenReturnOfPositions(); });
        }
        else
        {
            ChangesParent(parentTransform);
            faceZone.DeactivateToColliderZone();
            return HandChangesPosition(defaultPosition);
        }
    }

    protected Tween HandChangesPosition(Transform target)
    {
        return handRectTransform.DOMove(target.position, duration).SetEase(Ease.Linear);
    }
    protected Tween HandChangesPosition(Vector3 target)
    {
        return handRectTransform.DOMove(target, duration).SetEase(Ease.Linear);
    }

}