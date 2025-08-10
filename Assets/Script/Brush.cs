using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;

public class Brush : MakeupItems
{
    public Image MakeupChangeColor => makeupChangeColor;

    private Image makeupChangeColor;
    private Vector3 rotate = new Vector3(0, 0, 0);
    private Vector3 rotateEnd = new Vector3(0, 0, 90);

    public Tween TweenTakeItem(Image shadow)
    {
        makeupChangeColor = shadow;

        return HandChangesPosition(transform).
            OnKill(() => { transform.DORotate(rotate, duration); ChangesParent(handRectTransform); SafePosition(); faceZone.ActivateToColliderZone(); });
    }

    public Tween TakeShadow(Transform shadowTransform)
    {
        Sequence mySequence = DOTween.Sequence();
        Vector3 newPosition = new Vector3(shadowTransform.position.x + 40f, shadowTransform.position.y - 200f, shadowTransform.position.z);

        mySequence.Append(HandChangesPosition(new Vector3(shadowTransform.position.x, shadowTransform.position.y - 200f, shadowTransform.position.z)));
        mySequence.Append(HandChangesPosition(newPosition).SetLoops(4, LoopType.Yoyo));
        return mySequence.Play().OnComplete(() => HandChangesPosition(targetTowards));
    }

    public override Tween TweenReturnOfPositions()
    {
        if (previousPositions.Count > 0)
            return HandChangesPosition(previousPositions.Last()).
                OnComplete(() =>
                {
                    transform.DORotate(rotateEnd, duration);
                    RemoveLastPosition();
                }).
                    OnKill(() => TweenReturnOfPositions());
        else
        {
            transform.SetParent(parentTransform.transform);
            faceZone.DeactivateToColliderZone();
            return HandChangesPosition(defaultPosition).OnKill(() => RemoveLastPosition());
        }
    }
}
