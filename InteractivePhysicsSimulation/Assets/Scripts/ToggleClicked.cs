using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ToggleClicked : MonoBehaviour, IPointerClickHandler
{

    public GameObject Manager;
    private PlayingManager pm;

    private void Start()
    {
        pm = Manager.GetComponent<PlayingManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("OnPointerClicked");
        pm.ToggleStatic();
	}
}
