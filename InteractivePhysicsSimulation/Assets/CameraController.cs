using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float speedVertical = 2.0f;
    float speedHorizontal = 2.0f;

    float yaw = 0.0f;
    float pitch = 0.0f;

    public Transform transform;

	// Update is called once per frame
	void Update ()
    {
        //controls camera
        //yaw is inverted
        yaw += speedHorizontal * Input.GetAxis("Mouse X");
        pitch += speedVertical * -Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        Vector3 movement = new Vector3();

        //moves forward
        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0, 0, 1);
        }
        //moves backward
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0, 0, -1);
        }
        //moves right
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1, 0, 0);
        }
        //moves left
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1, 0, 0);
        }
        //moves up
        if (Input.GetKey(KeyCode.Q))
        {
            movement += new Vector3(0, 1, 0);
        }
        //moves down
        if (Input.GetKey(KeyCode.Z))
        {
            movement += new Vector3(0, -1, 0);
        }

        transform.position += movement;
	}
}
