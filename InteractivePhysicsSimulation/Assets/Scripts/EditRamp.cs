using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditRamp : MonoBehaviour
{

    public float angle = 45.0f;
    private float xScale;
    private float yScale;
    private float zScale;

	// Update is called once per frame
	void Update ()
    {
        if (angle <= 0 || angle >= 90)
        {
            angle = 45;
        }
        yScale = transform.localScale.y;
        xScale = transform.localScale.x;
        zScale = Mathf.Rad2Deg * Mathf.Atan(angle * Mathf.Deg2Rad * Mathf.Deg2Rad) * yScale;
        transform.localScale = new Vector3(xScale, yScale, zScale);
        Debug.Log(xScale+","+yScale+","+zScale);
    }
}
