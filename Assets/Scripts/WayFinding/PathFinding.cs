/**
 * author : Erric.Z
 * data : 2017.09.27
 * 
 * 注意事项1 ： 第一条路线长度最好长一点，当角色走到当前路线的倒数第二个区域的时候，需要重新计算路线。
 * 注意事项2 ： 根据第一条的规则，最后要留出5个点 -> 每条路线最少要放置4个点.<系统会额外分配两个点>。
 * 注意事项3 ： 当前游戏规则<游戏开始的直线道路放置10个点，那么其他所有道路都必须放置5个点>。
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
        
        int index = numSections - 2;

        int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);

        if (currPt == index)
            return true;

        return false;
    }


    public static Vector3 Velocity(Vector3[] source, float t)
    {
        int numSections = source.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)currPt;

        Vector3 a = source[currPt];
        Vector3 b = source[currPt + 1];
        Vector3 c = source[currPt + 2];
        Vector3 d = source[currPt + 3];

        return 1.5f * (-a + 3f * b - 3f * c + d) * (u * u)
                + (2f * a - 5f * b + 4f * c - d) * u
                + .5f * c - .5f * a;
    }

    public static void RecalculatePath(ref Vector3[] source, Vector3[] nextArea, ref float fRealPercent)             //重新计算路线
    {
        float per = fRealPercent % 1f;
        int numSections = source.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);

        fRealPercent = per * (float)numSections - (float)currPt;

        int index = numSections - 2;
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

        return  0.5f * (
            (-a + 3f * b - 3f * c + d) * (u * u * u)
            + (2f * a - 5f * b + 4f * c - d) * (u * u)
            + (-a + c) * u
            + 2f * b
        );
    }

    public static void GizmoDraw(Vector3[] source, float t)
    {
        Gizmos.color = Color.white;
        Vector3 prevPt = Interp(source, 0);

        for (int i = 1; i <= 20; i++)
        {
            float pm = (float)i / 20f;
            Vector3 currPt = Interp(source, pm);
            Gizmos.DrawLine(currPt, prevPt);
            prevPt = currPt;
        }

        Gizmos.color = Color.blue;
        Vector3 pos = Interp(source, t);
        Gizmos.DrawLine(pos, pos + Velocity(source, t).normalized);
    }






    
}
