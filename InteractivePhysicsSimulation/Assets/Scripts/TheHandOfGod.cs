using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheHandOfGod : MonoBehaviour {

    //public SelectedObjectControllerAndSelecter socas;
    public Dropdown ChooseObject;
    public RectTransform BuildPanelRect;
    public bool isBuildOptionsOpen;
    public GameObject MainCamera;
    private GameObject cx;
    private GameObject cy;
    private GameObject cz;
    public bool creating;

    private void Awake()
    {
        creating = false;
    }

    void Start () {
        creating = false;
        ChooseObject = GameObject.FindWithTag("ChooseObject").GetComponent<Dropdown>();
        BuildPanelRect = GameObject.Find("BuildPanel").GetComponent<RectTransform>();
        isBuildOptionsOpen = false;
        BuildPanelRect.anchoredPosition = new Vector3(-200, 0, 0);
        MainCamera = GameObject.FindWithTag("MainCamera");
        cx = GameObject.Find("CreatedX");
        cy = GameObject.Find("CreatedY");
        cz = GameObject.Find("CreatedZ");
        creating = false;
    }

    public void ToggleBuildOptions()
    {
        isBuildOptionsOpen = !isBuildOptionsOpen;
        if (isBuildOptionsOpen)
        {
            BuildPanelRect.anchoredPosition = new Vector3(0,0,0);
        }
        else
        {
            BuildPanelRect.anchoredPosition = new Vector3(-200, 0, 0);
        }
    }

    public void HoldSpawnEgg()
    {
        
        ThrowSpawnEgg("null");
    }

    public Vector3 p;

    public void ThrowSpawnEgg(string prefab)
    {
        creating = true;
        if (ChooseObject.value == 0)
            prefab = "Cube";
        if (ChooseObject.value == 1)
            prefab = "Ramp";
        if (ChooseObject.value == 2)
            prefab = "Sphere";
        if (ChooseObject.value == 3)
            prefab = "Plane";
        if (ChooseObject.value == 4)
            prefab = "Cylinder";
        Debug.Log(prefab);
        p = new Vector3(float.Parse(cx.GetComponent<InputField>().text), float.Parse(cy.GetComponent<InputField>().text), float.Parse(cz.GetComponent<InputField>().text));
        var tmp = Instantiate(Resources.Load("Prefabs/"+ prefab)) as GameObject;
        tmp.GetComponent<SelectedObjectControllerAndSelecter>().rsPos = p;

    }
}
