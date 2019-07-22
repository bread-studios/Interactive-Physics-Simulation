using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettingsManager : MonoBehaviour {

    bool gswOpen;
    GameObject gsButton;

	// Use this for initialization
	void Start () {
        gsButton = GameObject.FindWithTag("SettingsButton"); //Note to self: Make the glob settings panel open and close on a click
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
