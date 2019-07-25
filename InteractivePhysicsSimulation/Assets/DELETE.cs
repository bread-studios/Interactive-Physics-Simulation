using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DELETE : MonoBehaviour {

    private void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true; 
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

}
