using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightDetectionUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool isGUIHighlighted;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //do stuff when highlighted
        isGUIHighlighted = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //do stuff when unhighlighted
        isGUIHighlighted = false;
    }

}
