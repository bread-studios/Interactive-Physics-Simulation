using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditRamp : MonoBehaviour
{

    public float angle;
    private float trueAngle;
    private float xScale;
    private float yScale;
    private float zScale;

	// Update is called once per frame
	void Update ()
    {
        if (angle <= 0)
        {
            angle = 0.000000001f;
        }
        if (angle >= 90)
        {
            angle = 90;
        }
        trueAngle = angle * Mathf.Deg2Rad;
        yScale = transform.localScale.y;
        xScale = transform.localScale.x;
        zScale = Mathf.Tan(trueAngle) * yScale;
        transform.localScale = new Vector3(xScale, yScale, zScale);
<<<<<<< HEAD
        transform.position = new Vector3(transform.position.x, (zScale/100) , transform.position.z);
=======
        //Debug.Log(xScale+","+yScale+","+zScale);
>>>>>>> 256de74736bc6571eb78027df7894bf616c6ff45
    }
}
