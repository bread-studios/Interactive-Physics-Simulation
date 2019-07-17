using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    public GameObject Selected;
    private SelectedObjectControllerAndSelecter soos;

    private void Start()
    {

    }

    public void ReactToPropertyChange()
    {
        soos = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        soos.KidsReactToPropertyDamage();
    }
}
