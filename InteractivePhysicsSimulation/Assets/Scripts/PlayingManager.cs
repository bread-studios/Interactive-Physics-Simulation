using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {

    public GameObject Selected;
    public GameObject PropertiesPanel;
    public SelectedObjectControllerAndSelecter socas;
    public RigidBodyManager rbm;
    public bool isSliderChanged;
    private void Start()
    {
        PropertiesPanel.SetActive(true);
    }

    public bool IsPlaying = false;

    private void Update()
    {
        if (Input.GetKeyUp("p"))
        {
            TogglePlayPause();
        }
        if(Selected == null)
        {
            PropertiesPanel.SetActive(false);
        }
        else
        {
            PropertiesPanel.SetActive(true);
        }
    }


    public void TogglePlayPause()
    {
        Debug.Log("toggled play/pause");
        IsPlaying = !IsPlaying; 
    }
    public void ReactToPropertyChange()
    {
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        socas.KidsReactToPropertyDamage();
    }

    public void ToggleStatic()
    {
        Debug.Log("ToggleStatic");
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        rbm = Selected.GetComponent<RigidBodyManager>();
            rbm.isStatic = !rbm.isStatic;
    }

    public void SliderChanged()
    {
        isSliderChanged = true;
    }

    public void NotSliderChanged()
    {
        isSliderChanged = false;
    }
}
