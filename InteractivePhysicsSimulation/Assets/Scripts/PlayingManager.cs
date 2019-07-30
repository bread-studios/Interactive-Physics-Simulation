using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingManager : MonoBehaviour
{

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
        if (Input.GetKeyUp(KeyCode.P))
        {
            TogglePlayPause();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ToggleGlobalSettingsWindow();
        }
        if (Input.GetKey("escape"))
        {
            closeApplication();
        }
        if (Selected == null)
        {
            PropertiesPanel.SetActive(false);
        }
        else
        {
            PropertiesPanel.SetActive(true);
        }
        //Demo presets
        if (Input.GetKeyUp("z"))
        {
            Debug.Log("Tried to load scene 1");
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKeyUp("x"))
        {
            Debug.Log("Tried to load scene 2");
            SceneManager.LoadScene("Other");
        }
        if (Input.GetKeyUp("c"))
        {

        }
    }

    //Putting this in a class so that a button click may trigger it
    public void closeApplication()
    {
        Application.Quit();
    }

    public void TogglePlayPause()
    {
        IsPlaying = !IsPlaying;
    }
    public void ReactToPropertyChange()
    {
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        socas.KidsReactToPropertyDamage();
    }

    public void ToggleGlobalSettingsWindow()
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

    public void reset() {
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        socas.reset();
    }
}