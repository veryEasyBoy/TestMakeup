using DG.Tweening;
using UnityEngine;

public class HandRectTransformController : MonoBehaviour
{
    [Header("Target for towards")]
    [SerializeField] private RectTransform towardsTarget;
    [Header("Time to achieve the goal")]
    [SerializeField] private float duration;
    private TweenRectTransformComponent rectTransformComponent;
    private RectTransform myRectTransform;
    private void Awake()
    {
        myRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
        rectTransformComponent = new DefaultRectTransformComponent(myRectTransform);
    }
    // Двигает руку к таргету
    private Tween MovingTowards()
    {
        towardsTarget.position = myRectTransform.position;
        towardsTarget.SetParent(myRectTransform);
        return rectTransformComponent.GetTweenRectTransform(towardsTarget, duration);
    }
    // Двигает руку к таргету, затем двигает ее к добавленному таргету
    private Tween AddTargetMovingTowards(RectTransform addTarget)
    {
        rectTransformComponent = new AddTowardsTarget(rectTransformComponent,myRectTransform, addTarget);
        return rectTransformComponent.GetTweenRectTransform(towardsTarget, duration);
    }
    public void StartAddMovingTowards(RectTransform addTarget) => AddTargetMovingTowards(addTarget);
    public void StartMovingTowards() => MovingTowards();
}
