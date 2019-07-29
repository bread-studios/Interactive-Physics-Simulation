/**
 * This class is where all global variables will be managed and changed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSettingsManager : MonoBehaviour {

    private GameObject m;
    private GameObject GridMaker;
    private GameObject gridToggle;
    

	//Initialize all GameObjects
	void Start () {
        m = GameObject.FindWithTag("Manager");
        GridMaker = GameObject.FindWithTag("GridMaker");
        gridToggle = GameObject.Find("GridCB");
	}
	
	void Update () {
		if (gridToggle.GetComponent<Toggle>().isOn)
        {
            GridMaker.SetActive(true);
        }
        else
        {
            GridMaker.SetActive(false);
        }
	}
}
