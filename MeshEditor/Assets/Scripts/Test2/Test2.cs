/****************************************************
    文件：Test2.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class Test2 : MonoBehaviour
{
    public int X, Y;
    private Vector3[] _vertices;
    private Vector2[] _uv;
    private Vector3[] _normals;

    private void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "mesh2";
        var meshfilter = GetComponent<MeshFilter>();
        meshfilter.mesh = mesh;
        _vertices = new Vector3[(X + 1) * (Y + 1)];
        _uv = new Vector2[_vertices.Length];
        _normals = new Vector3[_vertices.Length];
        StartCoroutine(GeneratePlane(mesh));
    }

    private IEnumerator GeneratePlane(Mesh mesh)
    {
        yield return GenerateVertices();
        mesh.vertices = _vertices;
        mesh.uv = _uv;
        mesh.normals = _normals;
        yield return GenerateTriangles(mesh);
    }

    private IEnumerator GenerateTriangles(Mesh mesh)
    {
        int[] triangles = new int[X * Y * 6];
        for (int startIndex = 0 ,x = 0 , triangleIndex =0 ; startIndex < triangles.Length && x < X && startIndex < triangles.Length ; startIndex++ ,x++)
        {
            for (int y = 0; y < Y; y++,startIndex ++,triangleIndex += 6)
            {
                //当前四边形第一个三角形
                triangles[triangleIndex] = startIndex;
                triangles[triangleIndex +1] = startIndex +1;
                triangles[triangleIndex +2] = startIndex + X;
                //当前四边形第二个三角形
                triangles[triangleIndex +3] = startIndex + 1;
                triangles[triangleIndex +4] = startIndex + X + 1;
                triangles[triangleIndex +5] = startIndex + X;
                mesh.triangles = triangles;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    private IEnumerator GenerateVertices()
    {
        for (int x = 0,i =0; x < X +1; x++)
        {
            for (int y = 0; y < Y +1 ; y++,i++)
            {
                _vertices[i] = new Vector3(x, y);
                _uv[i] = new Vector2((float)x / X, (float)y / Y);
                _normals[i] = GetNormal(y);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    private Vector3 GetNormal(int y)
    {
        if (y % 2==0)
        {
            return Vector3.up;
        }
        else
        {
            return Vector3.down;
        }
    }

    private void OnDrawGizmos()
    {
        if (_vertices == null) return;
        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i],0.2f);
        }
    }
}