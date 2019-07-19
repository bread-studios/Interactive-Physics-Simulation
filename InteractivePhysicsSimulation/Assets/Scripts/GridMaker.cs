﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class GridMaker : MonoBehaviour {

    public int GridSize;

    void Awake()
    {
        transform.position = new Vector3(-GridSize/2,0,-GridSize/2);
        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh  = new Mesh();
        List<Vector3> verticies = new List<Vector3>();

        List<int> indicies = new List<int>();
        for (int i = 0; i < GridSize; i++)
        {
            verticies.Add(new Vector3(i, 0, 0));
            verticies.Add(new Vector3(i, 0, GridSize));

            indicies.Add(4 * i + 0);
            indicies.Add(4 * i + 1);

            verticies.Add(new Vector3(0, 0, i));
            verticies.Add(new Vector3(GridSize, 0, i));

            indicies.Add(4 * i + 2);
            indicies.Add(4 * i + 3);
        }

        mesh.vertices = verticies.ToArray();
        mesh.SetIndices(indicies.ToArray(), MeshTopology.Lines, 0);
        filter.mesh = mesh;

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load("Materials/Grid") as Material;
        meshRenderer.material.color = Color.white;
    }

    private void Update()
    {
        
    }
}