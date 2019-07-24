using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {

    public GameObject Selected;
    public GameObject PropertiesPanel;
    public GameObject GlobOptionPanel;
    public SelectedObjectControllerAndSelecter socas;
    private void Start()
    {
        PropertiesPanel.SetActive(true);
        GlobOptionPanel.SetActive(false);
    }

    public bool IsPlaying = false;
    public bool GSPIsEnabled = false;

    private void Update()
    {
        if (Input.GetKeyUp("p"))
        {
            TogglePlayPause();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ToggleGlobalSettingsWindow();
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
    public void ToggleGlobalSettingsWindow() //Frick you muyang i'm doing it in this class
    {
        GSPIsEnabled = !GSPIsEnabled;
        GlobOptionPanel.SetActive(GSPIsEnabled);
    }
    public void TogglePlayButtonIcon()
    {
        //change icon
    }
}
