using UnityEngine;
using UnityEngine.EventSystems;

public class CheckPosition : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RectTransform draggableTransform;
    [SerializeField] private RectTransform draggableRect;
    void Start()
    {
        // Debug.Log(Camera.main.WorldToScreenPoint(transform.position));
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(å.position).
       // Debug.Log(transform.TransformPoint(transform.position));
       Debug.Log(transform.localPosition);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        draggableTransform.position = eventData.position;
        Debug.Log(eventData.position + "Event");
        Debug.Log(eventData.position + "Event");
    }
    private void Update()
    {
        
    }
}
