using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotItem : MonoBehaviour, IDropHandler
{
    
    [System.Serializable]
    public class AssignObjects
    {
        public GameObject Gear;
    }

    public AssignObjects assignObjects;


   // [HideInInspector]
    public bool Filled;

    public void OnDrop(PointerEventData eventData)
    {
        if(!Filled)
        {           
            assignObjects.Gear.SetActive(true);
            assignObjects.Gear.GetComponent<Image>().color = eventData.pointerDrag.GetComponent<Image>().color;          
            eventData.pointerDrag.GetComponent<DragItem>().BackPosition();           
            eventData.pointerDrag.GetComponent<DragItem>().StartParent.gameObject.GetComponent<SlotItem>().Filled = false;           
            Filled = true;
            eventData.pointerDrag.SetActive(false);
            GameManager.Instance.CheckEndGame();
        } 
        
    }

}
