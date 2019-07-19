using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionProperties : MonoBehaviour {

    public Material Frictionless;
    private PhysicMaterial ChangeMaterial;
    public Collider Butter;
    public float dyn;
    public float stat;

	// Use this for initialization
	void Start () {
        // The collider is named butter
        Butter = GetComponent<Collider>();
        Butter.material.dynamicFriction = dyn;
        Butter.material.staticFriction = stat;
        //Butter.material.frictionCombine frickCom;
        //Butter.material.bounceCombine booCom;
	}

    // Update is called once per frame
    void Update()
    {

        int isSelected;

        // (Adjust later) If the object is on selection and 'F' is pressed, the object will turn frictionless

        if (Input.GetKeyDown(KeyCode.F) == true)
        {
        gameObject.GetComponent<PhysicMaterial>();
        dyn = 0;
        stat = 0;

        }
        else if (Input.GetKeyDown(KeyCode.F) == true)
        {
        gameObject.GetComponent<PhysicMaterial>();
        dyn = 1;
        stat = 1;
        }
    }
}
