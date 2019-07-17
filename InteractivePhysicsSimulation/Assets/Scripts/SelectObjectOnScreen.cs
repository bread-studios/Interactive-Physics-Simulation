using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectOnScreen : MonoBehaviour {

    private GameObject Manager;
    private SelectionManager sm;
    private Material SelectedMat;
    private Material DefaultMat;
    private Renderer rd;
    private bool amISelected;
    private void Start()
    {
        Manager = GameObject.FindWithTag("Manager");
        sm = Manager.GetComponent<SelectionManager>();
        rd = GetComponent<Renderer>();
        SelectedMat = Resources.Load("Materials/Selected", typeof(Material)) as Material;
        DefaultMat = Resources.Load("Materials/Default", typeof(Material)) as Material;
    }

    private void OnMouseDown()
    {
        sm.Selected = gameObject;
        rd.material = SelectedMat;
        StartCoroutine("Waiter");
        Debug.Log(gameObject.name);
    }
    private void Update()
    {
        if (sm.Selected == gameObject)
        {
            amISelected = true;
        }
        else
        {
            amISelected = false;
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitUntil(() => amISelected);
        yield return new WaitUntil(() => !amISelected);
        rd.material = DefaultMat;
    }

}
