using DG.Tweening;
using UnityEngine;

public class MovingTowardsObject : MonoBehaviour
{
    [SerializeField] RectTransform hand;
    [SerializeField] RectTransform rectTransform;
    public void MoveTowards()
    {
        Debug.Log(hand.transform.position + " h");
        Debug.Log(rectTransform.transform.position + " r");
        hand.DOMove(rectTransform.transform.position, 3f).SetEase(Ease.Linear);
    }
}
