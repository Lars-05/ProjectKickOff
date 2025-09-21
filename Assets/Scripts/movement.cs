using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class movement : MonoBehaviour 
{
    public Vector3 GetRandomPoint()
    {
        NavMeshTriangulation triangulation = NavMesh.CalculateTriangulation();
        int randNumber = Random.Range(0, triangulation.vertices.Length + 1);
        Vector3 vertexPos = triangulation.vertices[randNumber];
        return vertexPos;
    }
}