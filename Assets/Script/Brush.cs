using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;

public class Brush : MakeupItems
{
    public Image MakeupChangeSprite => makeupChangeSprite;

    private Image makeupChangeSprite;

    public Tween TweenTakeItem(Image shadow)
    {
        makeupChangeSprite = shadow;
        makeupActivityController.DeactiveCream();
        makeupActivityController.DeactiveLipstick();
        return HandChangesPosition(transform).
            OnKill(() =>
            {
                ChangesParent(handRectTransform);
                SafePosition();
            });
    }

    public Tween TakeShadow(Transform shadowTransform)
    {
        Sequence mySequence = DOTween.Sequence();
        Vector3 newPosition = new Vector3(shadowTransform.position.x + 40f, shadowTransform.position.y - 200f, shadowTransform.position.z);

        mySequence.Append(HandChangesPosition(new Vector3(shadowTransform.position.x, shadowTransform.position.y - 200f, shadowTransform.position.z)));
        mySequence.Append(HandChangesPosition(newPosition, 0.2f).SetLoops(4, LoopType.Yoyo));
        return mySequence.Play().OnComplete(() => HandChangesPosition(targetTowards));
    }

}
