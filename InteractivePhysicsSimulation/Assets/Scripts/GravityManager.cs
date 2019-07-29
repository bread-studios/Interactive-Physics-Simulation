﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityManager : MonoBehaviour
{

    public Vector3 direction;
    Vector3 currentDirection;

    public GameObject gravX;
    public GameObject gravY;
    public GameObject gravZ;

    //Set gravity to be regular earth gravity
    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        direction = enforceUpperLimit(10000, Physics.gravity);
        AntiGravityKidsReactToPropertyDamage();
    }

    void Update()
    {
        enforceUpperLimit(10000, direction);
        if (currentDirection != direction)
        {
            changeGravity(direction);
        }
        currentDirection = Physics.gravity;
        direction = Physics.gravity;
        if (Input.GetKeyUp(KeyCode.G))
        {
            Debug.Log("G key pressed, about to attempt to invert...");
            invertGravity('a');
            AntiGravityKidsReactToPropertyDamage();
        }
        else
        {
            AntiGravityParentsReactToKidDamage();
        }
    }

    //Update the text fields to show the current gravity vector
    void AntiGravityKidsReactToPropertyDamage()
    {
        gravX.GetComponent<InputField>().text = direction.x.ToString("g0");
        gravY.GetComponent<InputField>().text = direction.y.ToString("g0");
        gravZ.GetComponent<InputField>().text = direction.z.ToString("g0");

    }

    //Update the gravity vector to be what the text fields show
    void AntiGravityParentsReactToKidDamage()
    {
        direction = enforceUpperLimit(10000, new Vector3(float.Parse(gravX.GetComponent<InputField>().text),
            float.Parse(gravY.GetComponent<InputField>().text),
            float.Parse(gravZ.GetComponent<InputField>().text)));
        /*direction.x = float.Parse(gravX.GetComponent<InputField>().text);
        direction.y = float.Parse(gravY.GetComponent<InputField>().text);
        direction.z = float.Parse(gravZ.GetComponent<InputField>().text);*/
        Debug.Log("Update gravity to be text fields");
    }

    //If the gravity gets too high or low herobrine will haunt your game
    Vector3 enforceUpperLimit(int upperLimit, Vector3 direction)
    {
        if (direction.x > upperLimit)
            direction.x = upperLimit;
        if (direction.x < -upperLimit)
            direction.x = -upperLimit;
        if (direction.y > upperLimit)
            direction.y = upperLimit;
        if (direction.y < -upperLimit)
            direction.y = -upperLimit;
        if (direction.z > upperLimit)
            direction.z = upperLimit;
        if (direction.z < -upperLimit)
            direction.z = -upperLimit;
        Debug.Log("enforceUpperLimit " + upperLimit + " " + direction);
        return direction;
    }

    //Change gravity to a custom direction
    public void changeGravity(Vector3 direction)
    {
        this.direction = direction;
        Physics.gravity = direction;
        Debug.Log("changeGravity");
    }

    //Change gravity's magnitude, but keep it in the current direction
    public void invertGravity(char cDirection) //Valid args: x (x-dir), y (y-dir), z (z-dir), or a (all)
    {
        Debug.Log("Attempting to invert...");
        Vector3 g = Physics.gravity;
        if (cDirection == 'x')
            g.x = -g.x;
        if (cDirection == 'y')
            g.y = -g.y;
        if (cDirection == 'z')
            g.z = -g.z;
        if (cDirection == 'a')
            g = -g;
        Physics.gravity = g;
        this.direction = g;
        Debug.Log("invertGravity " + cDirection);
    }

}