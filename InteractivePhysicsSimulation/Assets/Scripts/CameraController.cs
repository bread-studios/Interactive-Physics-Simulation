using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivityVertical = 2.0f;
    public float mouseSensitivityHorizontal = 2.0f;
    public float cameraSpeed = 5.0f;

    float yaw = 0.0f;
    float pitch = 0.0f;

    void Start()
    {
        //makes all camera speeds positive
        if (cameraSpeed < 0)
            cameraSpeed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        //controls camera
        Cursor.visible = true;
        
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Confined;
            //yaw is inverted
            yaw += mouseSensitivityHorizontal * Input.GetAxisRaw("Mouse X");
            pitch += mouseSensitivityVertical * -Input.GetAxisRaw("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw + 90, 0.0f);
        }

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
        if (Input.GetKey("space"))
        {
            transform.position += Camera.main.transform.up * Time.deltaTime * cameraSpeed;
        }
        //moves down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += -Camera.main.transform.up * Time.deltaTime * cameraSpeed;
        }
    }
}
