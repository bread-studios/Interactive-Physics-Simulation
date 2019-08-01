using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingManager : MonoBehaviour
{
    public GameObject Selected;
    public GameObject PropertiesPanel;
    public GameObject GlobOptionPanel;
    private SelectedObjectControllerAndSelecter socas;
    private RigidBodyManager rbm;
    public PlayButtonController pbc;
    public GravityManager gm;
    public bool isSliderChanged;
    public bool enableDemoMaps;

    //Initialize vars and managers
    void Start()
    {
        PropertiesPanel.SetActive(true);
        GlobOptionPanel.SetActive(false);
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        rbm = Selected.GetComponent<RigidBodyManager>();
        gm = gameObject.GetComponent<GravityManager>();
        pbc = GameObject.FindWithTag("PlayButton").GetComponent<PlayButtonController>();
    }

    public bool IsPlaying = false;
    public bool GSPIsEnabled = false;

    private void Update()
    {
        //Hotkey implementation
        if (Input.GetKeyUp(KeyCode.P))
        {
            TogglePlayPause();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ToggleGlobalSettingsWindow();
        }
        //PropertiesPanel enable if object selected
        if (Selected == null)
        {
            PropertiesPanel.SetActive(false);
        }
        else
        {
            PropertiesPanel.SetActive(true);
        }
        //Demo presets
        if (enableDemoMaps == true)
        {
            if (Input.GetKeyUp("z"))
                SceneManager.LoadScene("Main");
            if (Input.GetKeyUp("x"))
                SceneManager.LoadScene("Other");
            if (Input.GetKeyUp("c"))
                SceneManager.LoadScene("Balls");
        }
    }


    public void TogglePlayPause()
    {
        Debug.Log("Toggle");
        if (gm.isTimerEnabled)
        {
            Debug.Log("1");
            StopCoroutine("Waiter");
            IsPlaying = !IsPlaying;
            StartCoroutine("Waiter");
        }
        else
        {
            Debug.Log("2");
            IsPlaying = !IsPlaying;
        }
    }

    public void ReactToPropertyChange()
    {


        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        socas.enabled = true;
        rbm = Selected.GetComponent<RigidBodyManager>();
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
        socas.enabled = true;
        rbm = Selected.GetComponent<RigidBodyManager>();
        rbm.isStatic = !rbm.isStatic;
    }

    public void SliderChanged()
    {
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        socas.enabled = true;
        rbm = Selected.GetComponent<RigidBodyManager>();
        isSliderChanged = true;
    }

    public void NotSliderChanged()
    {
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        socas.enabled = true;
        rbm = Selected.GetComponent<RigidBodyManager>();
        isSliderChanged = false;
    }

    public void reset()
    {
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        socas.enabled = true;
        rbm = Selected.GetComponent<RigidBodyManager>();
        socas.reset();
    }

    public IEnumerator Waiter()
    {
        yield return new WaitForSeconds(gm.timerTime);
        if (IsPlaying)
        {
            IsPlaying = !IsPlaying;
            pbc.Switch();
        }
    }
}