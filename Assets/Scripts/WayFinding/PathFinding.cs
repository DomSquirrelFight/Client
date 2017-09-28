/**
 * author : Erric.Z
 * data : 2017.09.27
 * 
 * 注意事项1 ： 第一条路线长度最好长一点，当角色走到当前路线的倒数第二个区域的时候，需要重新计算路线。
 * 注意事项2 ： 根据第一条的规则，最后要留出4个点 -> 每条路线最少要放置3个点.<系统会额外分配两个点>。
 * 注意事项3 ： 当前游戏规则<游戏开始的直线道路放置10个点，那么其他所有道路都必须放置6个点>。
 * 
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using AttTypeDefine;

public class PathFinding : MonoBehaviour
{


    public static Vector3[] InitializePointPath(Transform[] points)
    {

        Vector3[] source = new Vector3[points.Length];
        for (int i = 0; i < source.Length; i++)
        {
            source[i] = points[i].transform.position;
        }

        Vector3[] outputs = new Vector3[points.Length + 2];

        Array.Copy(source, 0, outputs, 1, source.Length);

        outputs[0] = outputs[1] + outputs[1] - outputs[2];

        outputs[outputs.Length - 1] = outputs[outputs.Length - 2] + outputs[outputs.Length - 2] - outputs[outputs.Length - 3];
 
        return outputs;

    }

    public static bool CheckRecalculatePath(Vector3[] source, float per)          //判定是否重新计算路线
    {

        int numSections = source.Length - 3;
        
        int index = numSections - 1;

        int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);

        if (currPt == index)
            return true;

        return false;
    }

    public static void RecalculatePath(ref Vector3[] source, Vector3[] nextArea, ref float fRealPercent)             //重新计算路线
    {
        fRealPercent = 0f;
        int numSections = source.Length - 3;

        int index = numSections - 1;
        //int index = source.Length - 4;
        Vector3[] tmp = new Vector3[source.Length];
        Array.Copy(source, index, tmp, 0, source.Length - index - 1);
        for (int i = index - 1; i >= 0; i--)
        {
            tmp[tmp.Length - 1 - i - 1] = nextArea[index - 1 - i];
        }

        tmp[tmp.Length - 1] = tmp[tmp.Length - 2] + tmp[tmp.Length - 2] - tmp[tmp.Length - 3];

        Array.Copy(tmp, source, tmp.Length);

    }


    public static Vector3 Interp(Vector3[] source, float per)    //插值获取路线点坐标
    {

        int numSections = source.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);

        float u = per * (float)numSections - (float)currPt;

        Vector3 a = source[currPt];
        Vector3 b = source[currPt + 1];
        Vector3 c = source[currPt + 2];
        Vector3 d = source[currPt + 3];

        return .5f * (
            (-a + 3f * b - 3f * c + d) * (u * u * u)
            + (2f * a - 5f * b + 4f * c - d) * (u * u)
            + (-a + c) * u
            + 2f * b
        );
    }







    
}
