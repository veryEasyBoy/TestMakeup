
using DG.Tweening;
using UnityEngine;

public interface ICommand
{
    public Tween Execute( float duration);
    public void Undo(float duration);
}
