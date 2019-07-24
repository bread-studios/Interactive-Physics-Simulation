using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyManager : MonoBehaviour
{
    private GameObject Manager;
    private PlayingManager pm;
    private bool IsPlayingDelayed;
    private SelectedObjectControllerAndSelecter socas;
    public float mass;
    public Vector3 vel;
    public Vector3 rot;
    public Vector3 acc;//Not used yet
    public bool isStatic;
    void Start()
    {
        Manager = GameObject.FindWithTag("Manager");
        pm = Manager.GetComponent<PlayingManager>();
        freezeComponent(GetComponent<Rigidbody>(), true);
    }

    private void Update()
    {
        if (pm.IsPlaying && !(GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeAll))
        {
            vel = GetComponent<Rigidbody>().velocity*100;
            rot = GetComponent<Rigidbody>().angularVelocity*100;
            mass = GetComponent<Rigidbody>().mass;
        }
        
        if (!isStatic)
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
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                RigidbodyConstraints.FreezePositionZ;
        }
        
    }

    /*Public method that freezes one specific object mid-air
    * In order to store velocity, global variable vel must be created in each
    * c# script that calls this method without calling this class too
    */
    public void freezeComponent(Rigidbody r, bool pause)
    {
        if (!isStatic)
        {
            if (pause == true)
            {
                vel = r.velocity*100;
                rot = r.angularVelocity*100;
                mass = r.mass;
                r.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                RigidbodyConstraints.FreezePositionZ;
            }
            else
            {
                r.constraints &= ~(RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                RigidbodyConstraints.FreezePositionZ);
                r.velocity = vel/100;
                r.angularVelocity = rot/100;
                r.mass = mass;
            }
        }
        else
        {
            vel = new Vector3(0, 0, 0);
            rot = new Vector3(0, 0, 0);
        }
    }

    /*public float getAcceleration()
    {
        
    }*/
}
