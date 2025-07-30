using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class HandRectTransformController : MonoBehaviour
{
    [Header("Target for towards")]
    private RectTransform myRectTransform;
    [Header("Time to achieve the goal")]
    [SerializeField] private float duration;
    [SerializeField] private RectTransform addTarget;
    private RectTransform handRectTransform;
    [SerializeField] private CommandInvoker commandInvoker;
    private AddTowardsTarget addTowardsTarget;
    [SerializeField] private List<Vector3> previousPosition;
    [SerializeField] private RectTransform towardsObject;
    private ModelObjectAdded model;
    private Vector3 defaultPosition;
    private void Awake()
    {
        myRectTransform = GetComponent<RectTransform>();
        handRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
        defaultPosition = handRectTransform.position;
        model = new ModelObjectAdded(addTarget, handRectTransform, previousPosition, myRectTransform, defaultPosition);
        addTowardsTarget = new AddTowardsTarget(model);
    }
    // Двигает руку к таргету, затем двигает ее к добавленному таргету
    private void AddTargetMovingTowards()
    {
         addTowardsTarget.Execute(duration);
    }
    public void Undo()
    {
        addTowardsTarget.Undo(duration);
    }
    public void StartAddMovingTowards() => AddTargetMovingTowards();
}
