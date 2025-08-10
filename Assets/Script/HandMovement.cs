using UnityEngine;
using UnityEngine.EventSystems;

public class HandMovement : MonoBehaviour, IDragHandler
{
    private RectTransform handPosition;

    private void Start()
    {
        handPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        handPosition.anchoredPosition += eventData.delta;
    }
}
