using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shadow : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Color color;
    [SerializeField] private Image makeupChangeColor;

    private GraphicRaycaster graphicRaycaster;
    private static bool isPicked = false;
    private Brush brush;
    private Image makeupItemChangeColor;
    private MakeupItemActivityController makeupActivityController;

    private void Start()
    {
        makeupActivityController = FindFirstObjectByType<MakeupItemActivityController>();
        graphicRaycaster = GameObject.FindGameObjectWithTag("CanvasPalette").GetComponent<GraphicRaycaster>();
        makeupItemChangeColor = GameObject.FindGameObjectWithTag("Tail").GetComponent<Image>();
        brush = GameObject.FindGameObjectWithTag("Brush").GetComponent<Brush>();
    }

    public void TakeItem()
    {
        if (brush.NumberOfVectors == 0 && isPicked)
        {
            isPicked = false;
            TakeItem();
            return;
        }
        if (isPicked)
        {
            graphicRaycaster.enabled = false;
            brush.TweenReturnOfPositions().OnComplete(() =>
            {
                isPicked = false;
                makeupActivityController.AllActivityMakeupItems();
            });
            return;
        }
        else
        {
            graphicRaycaster.enabled = false;
            brush.TweenTakeItem(makeupChangeColor).
                OnComplete(() => brush.
                TakeShadow(transform).
                OnKill(() =>
                {
                    SetColor();
                    graphicRaycaster.enabled = true;
                    isPicked = true;
                }));
            return;
        }
    }

    private Image SetColor()
    {
        makeupItemChangeColor.color = new Color(color.r, color.g, color.b);
        return makeupItemChangeColor;
    }
}
