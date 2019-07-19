using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {

    public GameObject Selected;
    public GameObject PropertiesPanel;
    public SelectedObjectControllerAndSelecter socas;
    public GravityManager gravm;
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
        if (Input.GetKeyUp(KeyCode.G))
        {
            MyBossIsGonnaFlipWhenHeSeesThis();
        }
        if (Selected == null)
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
    public void MyBossIsGonnaFlipWhenHeSeesThis()
    {
        gravm = GetComponent<GravityManager>();
        gravm.invertGravity('a');
    }
}
