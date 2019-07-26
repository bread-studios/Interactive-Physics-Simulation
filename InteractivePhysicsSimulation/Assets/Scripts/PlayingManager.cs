using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {

    public GameObject Selected;
    public GameObject PropertiesPanel;
    public GameObject GlobOptionPanel;
    public SelectedObjectControllerAndSelecter socas;
    public RigidBodyManager rbm;
    public bool isSliderChanged;

    private void Start()
    {
        PropertiesPanel.SetActive(true);
        GlobOptionPanel.SetActive(false);
    }

    public bool IsPlaying = false;
    public bool GSPIsEnabled = false;

    private void Update()
    {
        //Toggle playing or paused
        if (Input.GetKeyUp("p"))
        {
            TogglePlayPause();
        }
        //Toggle the appearance of the global settings panel
        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            ToggleGlobalSettingsWindow();
        }
        //If nothing selected, don't show the properties panel
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
    public void ToggleGlobalSettingsWindow() //Frick you muyang i'm doing it in this class
    {
        GSPIsEnabled = !GSPIsEnabled;
        GlobOptionPanel.SetActive(GSPIsEnabled);
    }
    public void ToggleStatic()
    {
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
