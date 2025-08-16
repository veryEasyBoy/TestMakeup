using UnityEngine;
using UnityEngine.EventSystems;

public class DragMovement : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
    }
}
