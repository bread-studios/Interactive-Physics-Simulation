using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {

    public Vector3 direction;
    Vector3 currentDirection;

	//Set gravity to be regular earth gravity
	void Start () {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        direction = Physics.gravity;
	}
	
	//
	void Update () {
        enforceUpperLimit(10000);
        if (Input.GetKeyUp(KeyCode.G))
        {
            invertGravity('a');
        }
		if (currentDirection != direction)
        {
            changeGravity(direction);
        }
        currentDirection = Physics.gravity;
        direction = Physics.gravity;
    }

    //If the gravity gets too high or low herobrine will haunt your game
    void enforceUpperLimit(int upperLimit)
    {
        if (direction.x > upperLimit)
        {
            direction.x = upperLimit;
        }
        if (direction.x < -upperLimit)
        {
            direction.x = -upperLimit;
        }
        if (direction.y > upperLimit)
        {
            direction.y = upperLimit;
        }
        if (direction.y < -upperLimit)
        {
            direction.y = -upperLimit;
        }
        if (direction.z > upperLimit)
        {
            direction.z = upperLimit;
        }
        if (direction.z < -upperLimit)
        {
            direction.z = -upperLimit;
        }
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
