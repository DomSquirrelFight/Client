/**
 * author : Erric.Z
 * data : 2017.09.27
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using AttTypeDefine;

public class PathFinding : MonoBehaviour
{

    /// <summary>
    /// 原理 ： 在路线的起点和终点的前面和后面生成两个点
    /// 目的 ： 对于起点来说，新生成的第一个点，保证了 01和12的线段斜率一致。
    /// </summary>
    /// <returns>寻路路径点数组</returns>
    public static Vector3[] PathControlPointController(Vector3[] path, Vector3 startpoint = default(Vector3), Vector3 endpoint = default(Vector3))                              //生成寻路路径点数组
    {

        //新建一个数组，数组的长度是传入数组长度 + 2.
        Vector3[] output = new Vector3[path.Length + 2];

        Array.Copy(path, 0, output, 1, path.Length);

        if (startpoint == default(Vector3))
        {
            output[0] = path[1] + path[1] - path[2];
        }
        else
        {
            output[0] = startpoint;
        }


        if (endpoint == default(Vector3))
        {
            output[output.Length - 1] = output[output.Length - 2] + output[output.Length - 2] - output[output.Length - 3];   
        }
        else
        {
            output[output.Length - 1] = endpoint;
        }

        return output;
    }
    

    public static Vector3 Interp(Vector3[] pts, float t)
    {
        int numSections = pts.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)currPt;
        if (t < 0f)
            Debug.Log(123);
        Vector3 a = pts[currPt];
        Vector3 b = pts[currPt + 1];
        Vector3 c = pts[currPt + 2];
        Vector3 d = pts[currPt + 3];

        return .5f * (
            (-a + 3f * b - 3f * c + d) * (u * u * u)
            + (2f * a - 5f * b + 4f * c - d) * (u * u)
            + (-a + c) * u
            + 2f * b
        );
    }

    public static Vector3[] GetPointPos(Transform[] t)
    {

        Vector3[] suppliedPath = new Vector3[t.Length];
        for (int i = 0; i < t.Length; i++)
        {
            suppliedPath[i] = t[i].position;
        }

        return suppliedPath;
      
    }
    
}
