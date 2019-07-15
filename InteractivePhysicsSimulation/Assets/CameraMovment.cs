using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour {

    //Mouse direction
    private Vector2 mD;

    public void Start()
    {

    }

    public void Update()
    {
        Vector2 mC = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }
}
