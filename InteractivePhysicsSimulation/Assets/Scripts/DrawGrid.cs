using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGrid : MonoBehaviour {

    Vector3 dim;
    float len;
    int gridSize;

	// Draw the grid on the ground at the start
	void Start () {

        dim = GetComponent<Renderer>().bounds.size;
        len = dim.x;
        gridSize = 1000;

        for (int i = 0; i < 100; i++)
        {
            Debug.DrawLine(new Vector3((len*i)/gridSize, 0f, len/2), new Vector3(0, 0, 0), Color.red);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
