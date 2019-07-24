using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionProperties : MonoBehaviour
{

    private Material Frictionless;
    private PhysicMaterial ChangeMaterial;
    public Collider Butter;

    // Use this for initialization
    void Start()
    {
        Butter = GetComponent<Collider>();
        Butter.material.dynamicFriction = 1f;
        Butter.material.staticFriction = 1f;
        Butter.material.bounciness = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // (Adjust later) If the object is on selection and 'F' is pressed, the object will turn frictionless
        //Friction
        if (Input.GetKeyDown(KeyCode.F) == true)
        {

            Butter.material.dynamicFriction = 0f;
            Butter.material.staticFriction = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.F) == true)
        {
            Butter.material.dynamicFriction = 1f;
            Butter.material.staticFriction = 1f;
        }

        // Bounciness
        if (Input.GetKeyDown(KeyCode.B) == true)
        {
            Butter.material.bounciness = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.B) == true)
        {
            Butter.material.bounciness = 0f;
        }

    }
}


