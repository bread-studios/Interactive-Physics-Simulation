using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
    public AudioSource s;
    public AudioClip tap;
    public AudioClip touch;
    public AudioClip dweep;
    public AudioClip dweep2;
    public AudioClip increase;
    public AudioClip collected;     

    void Start () {
        s = GetComponent<AudioSource>();
	}
	
    public void tapSound()
    {
        s.clip = tap;
        s.Play();
    }
    public void touchSound()
    {
        s.clip = touch;
        s.Play();
    }
    public void dweepSound()
    {
        s.clip = dweep;
        s.Play();
    }
    public void increaseSound()
    {
        s.clip = increase;
        s.Play();
    }
    public void collectedSound()
    {
        s.clip = collected;
        s.Play();
    }
    public void dweepSound2()
    {
        s.clip = dweep2;
        s.Play();
    }

    /*void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            s.clip = tap;
            s.Play();
        }
	}*/
}
