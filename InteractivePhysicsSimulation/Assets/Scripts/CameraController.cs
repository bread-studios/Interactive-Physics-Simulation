using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivityVertical;
    public float mouseSensitivityHorizontal;
    public float cameraStartSpeed;
    public float cameraAccel;
    public float cameraSpeed;
    public float maxCameraSpeed;
    private Quaternion initRot;

    float yaw = 0.0f;
    float pitch = 0.0f;
    float roll = 0.0f;

    void Start()
    {
        //makes all camera speeds positive
        if (cameraSpeed < 0)
        {
            cameraSpeed *= -1;
        }
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            //yaw is inverted

            if (Input.GetKey(KeyCode.LeftAlt))
            {
                roll += mouseSensitivityHorizontal * -Input.GetAxisRaw("Mouse X");
                pitch += mouseSensitivityVertical * -Input.GetAxisRaw("Mouse Y");
            }
            else
            {
                yaw += mouseSensitivityHorizontal * Input.GetAxisRaw("Mouse X");
                pitch += mouseSensitivityVertical * -Input.GetAxisRaw("Mouse Y");
                roll = 0;
            }
            transform.eulerAngles = new Vector3(pitch + initRot.eulerAngles.x, yaw + initRot.eulerAngles.y, roll + initRot.eulerAngles.z);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
        {
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
                transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed * Time.deltaTime, transform.position.z);

            }
            //moves down
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - cameraSpeed * Time.deltaTime, transform.position.z);

            }

            cameraSpeed += cameraAccel;
            if (cameraSpeed > maxCameraSpeed)
            {
                cameraSpeed = maxCameraSpeed;
            }
        }
        else
        {
            cameraSpeed = cameraStartSpeed;
        }
    }
}