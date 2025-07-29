using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnimationsCreamActive : BaseMoveTowards
{
    [SerializeField] private Image sprite;
    [SerializeField] private RectTransform target;
    [SerializeField] private HandRectTransformController controller;
    private void Start()
    {
        handTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }
    public void StartAnimations()
    {
        GetTweenRectTransform(target, duration).SetLoops(2, LoopType.Yoyo).OnStepComplete(() => DeactiveImage());
    }
    private void DeactiveImage()
    {
        gameObject.SetActive(false);
        controller.Undo();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartAnimations();
    }
}
