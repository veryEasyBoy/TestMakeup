using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    private readonly Player player = new Player();
    private IAction currentAction;
    private void Start()
    {
        currentAction = new ICream();
    }
    public void SetAction(IAction newAction)
    {
        if (newAction == null)
            throw new System.Exception(null);
        currentAction = newAction;
    }
    private void Update()
    {
        player.DoAction(currentAction);
    }
}
