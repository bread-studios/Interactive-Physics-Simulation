using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {

    /*private RigidBodyManager rbm;

    private void Start()
    {
        rbm = GameObject.FindGameObjectsWithTag("Object");
    }*/

    public bool IsPlaying = false;

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            TogglePlayPause();
        }
    }


    public void TogglePlayPause()
    {

        Debug.Log("toggled play/pause");
        IsPlaying = !IsPlaying;
        
    }
}
