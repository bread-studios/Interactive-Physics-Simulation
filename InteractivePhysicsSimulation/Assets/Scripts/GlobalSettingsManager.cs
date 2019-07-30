/**
 * This class is where most global variables will be managed and changed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSettingsManager : MonoBehaviour {

    //Managers
    private GameObject m;

    //Other GameObjects
    private GameObject GridMaker;
    private GameObject gridToggle;
    
	//Define all GameObjects
	void Start () {
        m = GameObject.FindWithTag("Manager");
        GridMaker = GameObject.FindWithTag("GridMaker");
        gridToggle = GameObject.Find("GridCB");
	}
	
	void Update () {
        //Grid Toggle Check Box
        if (gridToggle.GetComponent<Toggle>().isOn)
            GridMaker.SetActive(true);
        else
            GridMaker.SetActive(false);
    }
}
