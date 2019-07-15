using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	//If press space, return velocity in console
	void Update () {
        if (Input.GetKey("space"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | 
            RigidbodyConstraints.FreezePositionZ;
        }
	}

    public float getVelocity()
    {
        return 1f;
    }

    /*public float getAcceleration()
    {
        
    }*/
}
