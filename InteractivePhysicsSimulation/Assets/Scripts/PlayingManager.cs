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
        GlobOptionPanel.SetActive(true);
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        rbm = Selected.GetComponent<RigidBodyManager>();
        gm = gameObject.GetComponent<GravityManager>();
        pbc = GameObject.FindWithTag("PlayButton").GetComponent<PlayButtonController>();
    }

    public bool IsPlaying = false;
    public bool GSPIsEnabled = false;

    private void Update()
    {
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
            PropertiesPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(-200, 0 ,0);
        }
        else
        {
            socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
            socas.enabled = true;
            PropertiesPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        if (GSPIsEnabled)
        {
            GlobOptionPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else
        {
            GlobOptionPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 9999, 0);
        }
    }


    public void TogglePlayPause()
    {
        Debug.Log("Toggle");
        if (gm.isTimerEnabled)
        {
            StopCoroutine("Waiter");
            IsPlaying = !IsPlaying;
            StartCoroutine("Waiter");
        }
        else
        {
            IsPlaying = !IsPlaying;
        }
    }

    public void ReactToPropertyChange()
    {
        socas = Selected.GetComponent<SelectedObjectControllerAndSelecter>();
        rbm = Selected.GetComponent<RigidBodyManager>();
        socas.KidsReactToPropertyDamage();
    }

    public void ToggleGlobalSettingsWindow()
    {
        GSPIsEnabled = !GSPIsEnabled;
        if (GSPIsEnabled)
        {
            GlobOptionPanel.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            GlobOptionPanel.transform.position = new Vector3(0, 9999, 0);
        }
    }

    public void ToggleStatic()
    {
        rbm = Selected.GetComponent<RigidBodyManager>();
        rbm.isStatic = !rbm.isStatic;
    }

    public void SliderChanged()
    {
        rbm = Selected.GetComponent<RigidBodyManager>();
        isSliderChanged = true;
    }

    public void NotSliderChanged()
    {
        rbm = Selected.GetComponent<RigidBodyManager>();
        isSliderChanged = false;
    }

    public void reset()
    {
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