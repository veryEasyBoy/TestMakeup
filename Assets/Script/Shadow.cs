using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shadow : MakeupItemColorChange
{
    [SerializeField] private Image makeupChangeColor;
    private GraphicRaycaster graphicRaycaster;
    private static bool isPicked = false;
    private Brush brush;

    protected override void Start()
    {
        graphicRaycaster = GameObject.FindGameObjectWithTag("CanvasPalette").GetComponent<GraphicRaycaster>();
        makeupItemChangeColor = GameObject.FindGameObjectWithTag("Tail").GetComponent<Image>();
        brush = GameObject.FindGameObjectWithTag("Brush").GetComponent<Brush>();
        handRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }

    public void TakeBrush()
    {
        if (isPicked)
        {
            graphicRaycaster.enabled = false;
            brush.TweenReturnOfPositions().OnKill(() => { isPicked = false; graphicRaycaster.enabled = true; });
            return;
        }
        else
        {
            graphicRaycaster.enabled = false;
            brush.TweenTakeItem(makeupChangeColor).
                OnComplete(() => brush.
                TakeShadow(transform).
                OnKill(() => { SetColor(); graphicRaycaster.enabled = true; isPicked = true; } ));
            return;
        }
    }
}
