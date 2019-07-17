using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompileProperties : MonoBehaviour {
    //This script will compile the physical properties of a selected object when it is selcted by looking at other scripts, and then it will display them in the UI.

    private RigidBodyManager rbm;

    // Use this for initialization
    void Start() {
        rbm = GetComponent<RigidBodyManager>();
    }

    void Compile()
    {
        //Properties: rbm.vel for velocity, transform.[position, rotation, or scale].[x, y, or z] for transform properties
    }
	// Update is called once per frame
	void Update () {
		
	}
}
