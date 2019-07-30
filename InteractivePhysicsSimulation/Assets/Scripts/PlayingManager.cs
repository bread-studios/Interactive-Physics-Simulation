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
        socas.KidsReactToPropertyDamage();
    }

    public void ToggleGlobalSettingsWindow()
    {
        GSPIsEnabled = !GSPIsEnabled;
        GlobOptionPanel.SetActive(GSPIsEnabled);
    }

    public void ToggleStatic()
    {
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

    public void reset()
    {
        socas.reset();
    }

    public IEnumerator Waiter()
    {
        yield return new WaitForSeconds(gm.timerTime);
        if (IsPlaying)
        {
            pbc.Switch();
            IsPlaying = !IsPlaying;

        }
    }
}