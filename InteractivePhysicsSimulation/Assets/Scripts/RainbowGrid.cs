/**
 * Whatever this class is attached to will be rainbowy
 */
using UnityEngine;
using System.Collections;

public class RainbowGrid : MonoBehaviour
{

    public bool gay;

    Color[] colorList; //These will be the colors that will be switched between in this order
    Renderer r;
    float transitionTime = 4f;
    int iterator;

    void Start()
    {
        gay = true;
        r = GetComponent<Renderer>();
        colorList = new Color[6];
        colorList[0] = Color.red;
        colorList[1] = new Color(1f, 0.46f, 0.08f, 1f); //Orange
        colorList[2] = Color.yellow;
        colorList[3] = Color.green;
        colorList[4] = Color.blue;
        colorList[5] = Color.magenta;

        if (gay == true)
            StartCoroutine(RainbowColor());
    }

    IEnumerator RainbowColor()

    {
        while (true)
        {
            float transitionRate = 0f;
            r.material.SetColor("_Color", Color.Lerp(r.material.color, colorList[iterator], Time.deltaTime * transitionRate));
            r.material.SetColor("_EmmisionColor", Color.Lerp(r.material.color, colorList[iterator], Time.deltaTime * transitionRate));
            transitionRate += Time.deltaTime / transitionTime;
            iterator++;
            if (iterator >= 5)
                iterator = 0;
        }
    }

}