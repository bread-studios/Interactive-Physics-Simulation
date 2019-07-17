using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyManager : MonoBehaviour
{
    private GameObject Manager;
    private PlayingManager pm;
    private bool IsPlayingDelayed;
    public Vector3 vel;
    public Vector3 rot;
    public Vector3 acc; //Not used yet
    // Use this for initialization
    void Start()
    {
        Manager = GameObject.FindWithTag("Manager");
        pm = Manager.GetComponent<PlayingManager>();
        freezeComponent(GetComponent<Rigidbody>(), true);
    }

    //If press space, toggle pause
    private void Update()
    {
        if (pm.IsPlaying!=IsPlayingDelayed)
        {
            if (pm.IsPlaying == true)
            {
                freezeComponent(GetComponent<Rigidbody>(), false);
            }
            else if (pm.IsPlaying == false)
            {
                freezeComponent(GetComponent<Rigidbody>(), true);
            }
        }
        IsPlayingDelayed = pm.IsPlaying;
    }

    /*Public method that freezes one specific object mid-air
    * In order to store velocity, global variable vel must be created in each
    * c# script that calls this method without calling this class too
    */
    public void freezeComponent(Rigidbody r, bool pause)
    {
        if (pause == true)
        {
            vel = r.velocity;
            rot = r.angularVelocity;
            r.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
            RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            r.constraints &= ~(RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
            RigidbodyConstraints.FreezePositionZ);
            r.velocity = vel;
            r.angularVelocity = rot;

        }
    }

    /*public float getAcceleration()
    {
        
    }*/
}
