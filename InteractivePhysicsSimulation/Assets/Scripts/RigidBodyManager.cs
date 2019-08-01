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
    void Awake()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                RigidbodyConstraints.FreezePositionZ;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().angularDrag = 0;
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        Manager = GameObject.FindWithTag("Manager");
        pm = Manager.GetComponent<PlayingManager>();
        freezeComponent(GetComponent<Rigidbody>(), true);
    }

    private void Update()
    {
        if (pm.IsPlaying && !(GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeAll))
        {
            vel = GetComponent<Rigidbody>().velocity;
            rot = GetComponent<Rigidbody>().angularVelocity;
            mass = GetComponent<Rigidbody>().mass;
        }

        if (!isStatic)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            if (pm.IsPlaying != IsPlayingDelayed)
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
            GetComponent<Rigidbody>().isKinematic = true;
            /*GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                RigidbodyConstraints.FreezePositionZ;*/
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
                vel = r.velocity;
                rot = r.angularVelocity;
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
                r.velocity = vel;
                r.angularVelocity = rot;
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