using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyManager : MonoBehaviour
{
    Vector3 vel;
    bool paused = false;
    // Use this for initialization
    void Start()
    {
        
    }

    //If press space, toggle pause
    void Update()
    {
        if (Input.GetKeyUp("space") && paused)
        {
            Debug.Log("Unpaused");
            freezeComponent(GetComponent<Rigidbody>(), false);
        }
        else if (Input.GetKeyUp("space") && paused == false)
        {
            Debug.Log("Paused");
            freezeComponent(GetComponent<Rigidbody>(), true);
        }
    }

    /*Public method that freezes one specific object mid-air
    * In order to store velocity, global variable vel must be created in each
    * c# script that calls this method without calling this class too
    */
    public void freezeComponent(Rigidbody r, bool pause)
    {
        if (pause == true)
        {
            paused = true;
            vel = r.velocity;
            Debug.Log(vel);
            r.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
            RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            paused = false;
            r.constraints &= ~(RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
            RigidbodyConstraints.FreezePositionZ);
            r.velocity = vel;
            Debug.Log(vel);
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
