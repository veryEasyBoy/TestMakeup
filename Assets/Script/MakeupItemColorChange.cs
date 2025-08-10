using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MakeupItemColorChange : MonoBehaviour
{
    protected RectTransform handRectTransform;
    protected Image makeupItemChangeColor;

    [SerializeField] private float duration;
    [SerializeField] private Color color;

    protected virtual void Start()
    {
        makeupItemChangeColor = GameObject.FindGameObjectWithTag("Tail").GetComponent<Image>();
        handRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }

    public void ChangeColor()
    {
        StartMoveHand().OnStepComplete(() => SetColor());
    }

    protected Tween StartMoveHand()
    {
        return handRectTransform.DOMove(transform.position, duration).SetEase(Ease.Linear);
    }

    protected Image SetColor()
    {
        makeupItemChangeColor.color = new Color(color.r, color.g, color.b);
        return makeupItemChangeColor;
    }
}
