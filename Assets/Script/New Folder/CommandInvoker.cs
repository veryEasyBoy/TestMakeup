using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    [field:SerializeField] private Stack<ICommand> commandHistory = new Stack<ICommand>();
    public void Execute(ICommand command, float duration)
    {
        command.Execute(duration);
        commandHistory.Push(command);
    }
    public void Undo(ICommand command,float duration)
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory.Pop();
            lastCommand.Undo(duration);
        }
    }
}
