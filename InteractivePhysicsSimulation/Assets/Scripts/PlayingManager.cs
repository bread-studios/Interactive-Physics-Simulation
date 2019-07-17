using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {

    public GameObject PropertiesPanel;

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
    }


    public void TogglePlayPause()
    {
        if (PropertiesPanel.activeSelf) //deactivates/activates the properties panel
        {
            PropertiesPanel.SetActive(false);
        }
        else
        {
            PropertiesPanel.SetActive(true);
        }
        Debug.Log("toggled play/pause");
        IsPlaying = !IsPlaying;
        
    }
}
