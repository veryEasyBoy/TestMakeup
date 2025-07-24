using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler
{
    public RectTransform draggableTransform;
    public void OnDrag(PointerEventData eventData)
    {
        // Рассчитать новую позицию на основе дельты перетаскивания  
        draggableTransform.anchoredPosition += eventData.delta;
    }
}  
