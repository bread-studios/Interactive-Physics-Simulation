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
    public bool isViewSpecial = false; //Is it in top view, bottom view, right, left, etc. 
    public Vector3 FreeCamPos;
    public Vector3 FreeCamRot;
    public float pitch;
    public float yaw;
    public float roll;

    void Start()
    {
        //makes all camera speeds positive
        if (cameraSpeed < 0)
        {
            cameraSpeed *= -1;
        }
        //initRot = transform.rotation;

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
                yaw += mouseSensitivityHorizontal * Input.GetAxisRaw("Mouse X");
                roll += mouseSensitivityHorizontal * -Input.GetAxisRaw("Mouse X");
                pitch += mouseSensitivityVertical * -Input.GetAxisRaw("Mouse Y");
            }
            else
            {
                yaw += mouseSensitivityHorizontal * Input.GetAxisRaw("Mouse X");
                pitch += mouseSensitivityVertical * -Input.GetAxisRaw("Mouse Y");
                roll = 0;
            }

            transform.eulerAngles = new Vector3(pitch, yaw, roll);
            isViewSpecial = false;
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

    public void TopView()
    {
        if (isViewSpecial == true)
        {
            transform.position = FreeCamPos;
            transform.eulerAngles = FreeCamRot;
            pitch = FreeCamRot.z;
            yaw = FreeCamRot.y;
            roll = FreeCamRot.x;
        }else{
            isViewSpecial = true;
            FreeCamPos = transform.position;
            FreeCamRot = transform.eulerAngles;
            float tmp = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2)+Mathf.Pow(transform.position.y, 2)+Mathf.Pow(transform.position.z, 2));
            transform.position = new Vector3(0,tmp,0);
            pitch = 90;
            yaw = 0;
            roll = 0;
            transform.eulerAngles = new Vector3(pitch, yaw, roll);
        }
    }

}