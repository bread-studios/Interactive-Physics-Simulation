using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightDetectionUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool isPlayButtonHighlighted;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //do stuff when highlighted
        isPlayButtonHighlighted = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //do stuff when unhighlighted
        isPlayButtonHighlighted = false;
    }

}
