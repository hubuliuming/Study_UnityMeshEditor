/****************************************************
    文件：Test3.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class Test3 : MonoBehaviour
{
    private Vector3[] _vertices;
    private int[] _triangles;
    private void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "mesh3";
        var meshfilter = GetComponent<MeshFilter>();
        meshfilter.mesh = mesh;
        GenerateVertices();
        GenerateTriangles();
        mesh.vertices = _vertices;
        mesh.triangles = _triangles;
    }

    private void GenerateVertices()
    {
        _vertices = new Vector3[8];
        //下面的顶点
        _vertices[0] = new Vector3(-0.5f, -0.5f, -0.5f);
        _vertices[1] = new Vector3(0.5f, -0.5f, -0.5f);
        _vertices[2] = new Vector3(-0.5f, -0.5f, 0.5f);
        _vertices[3] = new Vector3(0.5f, -0.5f, 0.5f);
        //上面的顶点
        _vertices[4] = new Vector3(-0.5f, 0.5f, -0.5f);
        _vertices[5] = new Vector3(0.5f, 0.5f, -0.5f);
        _vertices[6] = new Vector3(-0.5f, 0.5f, 0.5f);
        _vertices[7] = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void GenerateTriangles()
    {
        _triangles = new int[2 * 6 * 3];
        //底面
        _triangles[0] = 0;
        _triangles[1] = 3;
        _triangles[2] = 2;
        _triangles[3] = 0;
        _triangles[4] = 1;
        _triangles[5] = 3;
        //正面
        _triangles[6] = 0;
        _triangles[7] = 4;
        _triangles[8] = 5;
        _triangles[9] = 0;
        _triangles[10] = 5;
        _triangles[11] = 1;
        //左面
        _triangles[12] = 2;
        _triangles[13] = 6;
        _triangles[14] = 4;
        _triangles[15] = 2;
        _triangles[16] = 4;
        _triangles[17] = 0;
        //右面
        _triangles[18] = 1;
        _triangles[19] = 5;
        _triangles[20] = 7;
        _triangles[21] = 1;
        _triangles[22] = 7;
        _triangles[23] = 3;
        //后面
        _triangles[24] = 2;
        _triangles[25] = 7;
        _triangles[26] = 6;
        _triangles[27] = 2;
        _triangles[28] = 3;
        _triangles[29] = 7;
        //上面
        _triangles[30] = 4;
        _triangles[31] = 6;
        _triangles[32] = 7;
        _triangles[33] = 4;
        _triangles[34] = 7;
        _triangles[35] = 5;
    }
    
    private void OnDrawGizmos()
    {
        if (_vertices == null) return;
        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(transform.TransformPoint(_vertices[i]), 0.2f);
        }
    }
}