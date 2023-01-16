/****************************************************
    文件：GenerateMesh_1.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class GenerateMesh_1 : MonoBehaviour 
{
    private void Start()
    {
        Mesh mesh1 = new Mesh();
        mesh1.name = "mesh1";
        var meshfilter = GetComponent<MeshFilter>();
        meshfilter.mesh = mesh1;
        //设置顶点信息
        mesh1.vertices = GetVertex();
        //设置绘制三角形坐标
        mesh1.triangles = GetTriangles();
        mesh1.uv = GetUV();
        //法向量赋值，接收光照影响
        mesh1.normals = GetNormals();
        
        // 切线 TFB， 最后一个Ｂ通常为-1
        //mesh1.tangents
    }

   

    private Vector3[] GetVertex()
    {
        return new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 0, 0),
        };
    }

    private Vector2[] GetUV()
    {
        return new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0),
        };
    }
    
    private Vector3[] GetNormals()
    {
        return new Vector3[]
        {
            Vector3.forward, 
            Vector3.forward, 
            Vector3.forward, 
            Vector3.forward, 
        };
    }

    private int[] GetTriangles()
    {
        return new int[]
        {
            0, 1, 2,
            0, 2, 3,
        };
    }

}