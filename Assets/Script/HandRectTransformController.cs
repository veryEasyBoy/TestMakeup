using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class HandRectTransformController : MonoBehaviour
{
    [Header("Target for towards")]
    [SerializeField] private RectTransform towardsTarget;
    [Header("Time to achieve the goal")]
    [SerializeField] private float duration;
    private TweenRectTransformComponent rectTransformComponent;
    [SerializeField] private RectTransform addTarget;
    private RectTransform myRectTransform;
    [SerializeField] private CommandInvoker commandInvoker;
    private AddTowardsTarget addTowardsTarget;
    [SerializeField] private List<Vector3> previousPosition;
    [SerializeField] private RectTransform towardsObject;
    private void Awake()
    {
        myRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
        rectTransformComponent = new DefaultRectTransformComponent(myRectTransform);
        addTowardsTarget = new AddTowardsTarget(rectTransformComponent, myRectTransform, previousPosition, addTarget, towardsObject);
    }
    // Двигает руку к таргету
    private Tween MovingTowards()
    {
        return rectTransformComponent.GetTweenRectTransform(towardsTarget, duration);
    }
    // Двигает руку к таргету, затем двигает ее к добавленному таргету
    private Tween AddTargetMovingTowards()
    {
        return addTowardsTarget.Execute(duration);
    }
    public void Undo()
    {
        addTowardsTarget.Undo(duration);
    }
    public void StartAddMovingTowards() => AddTargetMovingTowards();
    public void StartMovingTowards() => MovingTowards();
}
