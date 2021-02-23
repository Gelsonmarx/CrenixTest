using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    [System.Serializable]
    public class AssignObjects
    {
        public Canvas canvas;
    }

    public AssignObjects assignObjects;

    [HideInInspector]
    public Color color;

    RectTransform rect;
    CanvasGroup canvGroup;
    Vector2 StartPostion;
    [HideInInspector]
    public Transform StartParent;

    private void Awake()
    {
        color = GetComponent<Image>().color;
        StartParent = transform.parent;
        rect = GetComponent<RectTransform>();
        canvGroup = GetComponent<CanvasGroup>();
        StartPostion = rect.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {      
        transform.SetParent(assignObjects.canvas.transform);       
        canvGroup.blocksRaycasts = false;
        canvGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta/ assignObjects.canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        BackPosition(eventData);
    }

    public void BackPosition(PointerEventData eventData = null)
    {
        transform.SetParent(StartParent);
        canvGroup.blocksRaycasts = true;
        canvGroup.alpha = 1;
        if (this.gameObject.activeSelf)
        {
            rect.anchoredPosition = StartPostion;
        }
        
        
    }

}
