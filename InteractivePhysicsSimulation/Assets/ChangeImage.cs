using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {

    public Sprite start;
    public Sprite stop;
    Image image;

    public void Start()
    {
        image = GetComponent<Image>();
        image.sprite = stop;
    }

    public void changeSprite()
    {
        if (image.sprite.name.Equals("StopButton"))
        {
            image.sprite = start;
        }
        else if (image.sprite.name.Equals("StartButton"))
        {
            image.sprite = stop;
        }
    }
}
