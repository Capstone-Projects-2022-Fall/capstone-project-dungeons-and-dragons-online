using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class FieldOfView : MonoBehaviour
{
    // // [SerializeField] private LayerMask layerMask;
    // private Mesh mesh;

    // private void Start()
    // {
    //     Mesh mesh = new Mesh();
    //     GetComponent<MeshFilter>().mesh = mesh;
    // }

    // private void Update()
    // {

    //     float fov = 90f;
    //     Vector3 origin = Vector3.zero;
    //     int raycount = 50;
    //     float angle = 0f;
    //     float angleIncrease = fov / raycount;
    //     float viewdistance = 50f;

    //     Vector3[] vertices = new Vector3[raycount + 2];
    //     Vector2[] uv = new Vector2[vertices.Length];
    //     int[] triangles = new int[raycount * 3];

    //     vertices[0] = origin;
    //     int vertexIndex = 1;
    //     int triIndex = 0;
    //     for(int i = 0; i <= raycount; i++)
    //     {
    //         Vector3 vertex;
    //         RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewdistance);
    //         if(raycastHit2D.collider == null)
    //         {
    //             vertex = origin + GetVectorFromAngle(angle) * viewdistance;
    //         }
    //         else
    //         {
    //             vertex = raycastHit2D.point;
    //         }
    //         vertices[vertexIndex] = vertex;

    //         if(i > 0)
    //         {
    //             triangles[triIndex + 0] = 0;
    //             triangles[triIndex + 1] = vertexIndex - 1;
    //             triangles[triIndex + 2] = vertexIndex;

    //             triIndex += 3;
    //         }
    //         vertexIndex++;
    //         angle -= angleIncrease;
    //     }


    //     mesh.vertices = vertices;
    //     mesh.uv = uv;
    //     mesh.triangles = triangles;
    // }

    // private Vector3 GetVectorFromAngle(float angle)
    // {
    //     float angleRad = angle * (Mathf.PI/180f);
    //     return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    // }
}
