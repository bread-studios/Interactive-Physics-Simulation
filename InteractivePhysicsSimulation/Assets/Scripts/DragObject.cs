using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private GameObject Manager;
    private PlayingManager pm;
    private void Start() {
        Manager = GameObject.FindWithTag("Manager");
        pm = Manager.GetComponent<PlayingManager>();
    }
    void OnMouseDown()
    {
        Debug.Log("down");
        if (pm.Selected == gameObject)
        {
            Debug.Log("selected");
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        }
        
    }



    private Vector3 GetMouseAsWorldPoint()

    {
        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = mZCoord;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }



    void OnMouseDrag()
    {
        if (pm.Selected == gameObject)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }

}
