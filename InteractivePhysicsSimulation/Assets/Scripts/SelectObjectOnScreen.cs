using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectOnScreen : MonoBehaviour {

    private GameObject Manager;
    private SelectionManager sm;

    private void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        sm = Manager.GetComponent<SelectionManager>();
    }

    private void OnMouseDown()
    {
        sm.Selected = gameObject;
        Debug.Log(gameObject.name);
    }

}
