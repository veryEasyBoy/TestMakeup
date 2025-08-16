using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Lipstick : MakeupItems
{
    public Image MakeupChangeSprite => makeupChangeSprite;

    [SerializeField] private Image makeupChangeSprite;
    [SerializeField] private GraphicRaycaster graphicRaycaster;
    private static bool isPicked = false;
    private static int n = 0;

    public override void TakeItem()
    {
        if (!handRectTransform.GetComponentInChildren<Lipstick>() && isPicked)
        {
            isPicked = false;
            TakeItem();
            return;
        }
        if (isPicked && handRectTransform.GetComponentInChildren<Lipstick>())
        {
            graphicRaycaster.enabled = false;
            handRectTransform.GetComponentInChildren<Lipstick>().TweenReturnOfPositions().OnComplete(() =>
            {
                isPicked = false;
                makeupActivityController.AllActivityMakeupItems();
            });
            return;
        }
        else
        {
            n++;
            graphicRaycaster.enabled = false;
            makeupActivityController.DeactiveShadow();
            makeupActivityController.DeactiveCream();
            HandChangesPosition(transform).
            OnComplete(() =>
            {
                HandChangesPosition(targetTowards.position);
                SafePosition();
                ChangesParent(handRectTransform);
                graphicRaycaster.enabled = true;
                isPicked = true;
            });
            return;
        }
    }
}