using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityManager : MonoBehaviour {

    public InputField gravX;
    public InputField gravY;
    public InputField gravZ;
    public Vector3 direction;
    Vector3 currentDirection;
    float currentXText;
    float currentYText;
    float currentZText;

	//Set gravity to be regular earth gravity
	void Start () {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        direction = Physics.gravity;
        currentDirection = new Vector(0, 0, 0);
        gravX.text = "0";
        gravY.text = "-9.81";
        gravZ.text = "0";
        
    }
	
	//
	void Update () {
        enforceUpperLimit(10000);
        if (float.Parse(gravX.text) != currentXText)
        {
            direction.x = gravX.text;
        }
        if (float.Parse(gravY.text) != currentYText)
        {
            direction.y = gravY.text;
        }
        if (float.Parse(gravZ.text) != currentZText)
        {
            direction.z = gravZ.text;
        }
        if (currentDirection != direction)
        {
            changeGravity(direction);
            gravX.text = direction.x.ToString();
            gravY.text = direction.y.ToString();
            gravZ.text = direction.z.ToString();
        }
        
        currentDirection = Physics.gravity;
        direction = Physics.gravity;
        currentXText = gravX.text;
        currentYText = gravY.text;
        currentZText = gravZ.text;
    }

    //If the gravity gets too high or low herobrine will haunt your game
    void enforceUpperLimit(int upperLimit)
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
    }

    //Change gravity to a custom direction
    public void changeGravity(Vector3 direction)
    {
        Physics.gravity = direction;
    }

    //Change gravity's magnitude, but keep it in the current direction
    public void invertGravity(char direction) //Valid args: x (x-dir), y (y-dir), z (z-dir), or a (all)
    {
        Vector3 g = Physics.gravity;
        if (direction == 'x')
        {
            g.x = -g.x;    
        }
        if (direction == 'y')
        {
            g.y = -g.y;
        }
        if (direction == 'z')
        {
            g.z = -g.z;
        }
        if (direction == 'a')
        {
            g = -g;
        }
        Physics.gravity = g;
    }

}
