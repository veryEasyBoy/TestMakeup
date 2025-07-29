using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public void DoAction(IAction action)
    {
        action?.PerformAction();
    }
}
