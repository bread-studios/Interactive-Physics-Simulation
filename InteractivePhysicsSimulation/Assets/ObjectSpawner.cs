using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public GameObject prefab;
    public Transform spawn;
    private ArrayList objects;

    private void Start()
    {
        objects = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            StartCoroutine("SpawnBlock");
        }
    }

    IEnumerator SpawnBlock()
    {
        Instantiate(prefab, spawn);
        yield return new WaitForSeconds(1);
    }
}
