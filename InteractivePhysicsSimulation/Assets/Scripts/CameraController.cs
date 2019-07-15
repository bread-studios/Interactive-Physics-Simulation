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
    public float cameraSpeed = 5.0f;

    void Start()
    {
        if (cameraSpeed < 0)
            cameraSpeed *= -1;
    }

    // Update is called once per frame
    void Update()
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
            transform.position += Camera.main.transform.forward * Time.deltaTime * cameraSpeed;
        }
        //moves backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -Camera.main.transform.forward * Time.deltaTime * cameraSpeed;
        }
        //moves right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Camera.main.transform.right * Time.deltaTime * cameraSpeed;
        }
        //moves left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -Camera.main.transform.right * Time.deltaTime * cameraSpeed;
        }
        //moves up
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Camera.main.transform.up * Time.deltaTime * cameraSpeed;
        }
        //moves down
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += -Camera.main.transform.up * Time.deltaTime * cameraSpeed;
        }
    }
}
