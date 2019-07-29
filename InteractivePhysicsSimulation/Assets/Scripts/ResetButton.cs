using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour {

    public Button pressButton;
    public GameObject thingy;
    public InputField posi, rotate, scal, velo, angvelo;

    // Use this for initialization
    void Start () {
        thingy = FindObjectOfType<GameObject>();
        posi.GetComponent<RectTransform>().localPosition = Vector3.zero;
        rotate.GetComponent<RectTransform>().localPosition = Vector3.zero;
        

    }

    // Update is called once per frame
    void Update () {
        float posiX;
        float posiY;
        float posiZ;

        if (pressButton == true)
        {
                        
        }
	}
}
