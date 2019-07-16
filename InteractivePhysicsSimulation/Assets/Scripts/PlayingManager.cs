using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {

    public bool IsPlaying;

    public void TogglePlayPause()
    {
        IsPlaying = !IsPlaying;

    }
}
