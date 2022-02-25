using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private Canvas canvas_ = null;
    private RectTransform rectt_;

    private void Awake()
    {
        rectt_ = GetComponent<RectTransform>();
        canvas_ = GetComponentInParent<Canvas>(); //recurses upwards until it finds a GameObject with a matching component. Only components on active GameObjects are matched.
        if (canvas_ == null)
        {
            Debug.LogError("> KH_ERR: No Canvas component found in parents for " + transform.name);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("> OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("> OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("> OnEndDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("> OnDrag");
        rectt_.anchoredPosition += eventData.delta / canvas_.scaleFactor; //icon normally moves by screen position ratio of 1, but canvas has to scale to fit screen 
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("> OnDrop");
    }
}
