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

    public bool isTimerEnabled;

    public GameObject timerInput;
    public GameObject timerToggle;
    public float timerTime;

    public Vector3 startGrav;

    //Set gravity to be regular earth gravity
    void Start()
    {
        Physics.gravity = startGrav;
        direction = upperLimitVector(10000, Physics.gravity);
        AntiGravityKidsReactToPropertyDamage();
        isTimerEnabled = false;
    }

    void Update()
    {
        direction = upperLimitVector(10000, direction);
        if (currentDirection != direction)
        {
            changeGravity(direction);
        }
        currentDirection = Physics.gravity;
        direction = Physics.gravity;
        if (Input.GetKeyUp(KeyCode.G))
        {
            invertGravity('a');
            AntiGravityKidsReactToPropertyDamage();
        }
        else
        {
            AntiGravityParentsReactToKidDamage();
        }
    }

    public void toggleTimer()
    {
        isTimerEnabled = !isTimerEnabled;
    }

    //Update the text fields to show the current gravity vector
    public void AntiGravityKidsReactToPropertyDamage()
    {
        gravX.GetComponent<InputField>().text = direction.x.ToString("g0");
        gravY.GetComponent<InputField>().text = direction.y.ToString("g0");
        gravZ.GetComponent<InputField>().text = direction.z.ToString("g0");
    }

    //Update the gravity vector to be what the text fields show
    public void AntiGravityParentsReactToKidDamage()
    {
        if (isTimerEnabled) //this is line 69
        {
            timerTime = float.Parse(timerInput.GetComponent<InputField>().text);
        }
        direction = upperLimitVector(10000, new Vector3(float.Parse(gravX.GetComponent<InputField>().text),
            float.Parse(gravY.GetComponent<InputField>().text),
            float.Parse(gravZ.GetComponent<InputField>().text)));
    }

    //If the gravity gets too high or low herobrine will haunt your game
    public Vector3 upperLimitVector(int upperLimit, Vector3 direction)
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
        return direction;
    }

    //Change gravity to a custom direction
    public void changeGravity(Vector3 direction)
    {
        this.direction = direction;
        Physics.gravity = direction;
    }

    //Change gravity's magnitude, but keep it in the current direction
    public void invertGravity(char cDirection) //Valid args: x (x-dir), y (y-dir), z (z-dir), or a (all)
    {
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
    }

}