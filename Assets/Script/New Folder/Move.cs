using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private RectTransform addTarget;
    private RectTransform myRectTransform;
    [SerializeField] private float duration;
    private CommandInvoker commandInvoker;
    private MoveRectTransform moveRectTransform;
    void Start()
    {
        myRectTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
        commandInvoker = new CommandInvoker();
        moveRectTransform = new MoveRectTransform(myRectTransform, addTarget,duration);
    }

    public void Ex()
    {
        //commandInvoker.Execute(moveRectTransform);
    }
    public void Undo()
    {
        //commandInvoker.Undo(moveRectTransform);
    }
}
