
using DG.Tweening;
using UnityEngine;

public interface ICommand
{
    public void Execute( float duration);
    public void Undo(float duration);
}
