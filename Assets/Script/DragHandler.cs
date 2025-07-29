using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform draggableTransform;

    // ������ ����� �������
    public void OnDrag(PointerEventData eventData)
    {
        draggableTransform.anchoredPosition += eventData.delta;
    }
}  
