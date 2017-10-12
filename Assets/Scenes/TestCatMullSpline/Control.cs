#region namespace
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Assets.Scripts.WayFinding;
#endregion

namespace Assets.Scenes.TestCatmull
{

    public class Control : MonoBehaviour
    {

        public CatmullPathPoint[] Area1;
        public CatmullPathPoint[] Area2;
        Vector3[] CurRoute = null;

        void Start()
        {
             CurRoute = CalRoute(Area1);
        }
        
        Vector3[] CalRoute(CatmullPathPoint[] points)
        {

            Vector3[] source = new Vector3[points.Length];
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = points[i].transform.position;
            }

            Vector3[] outputs = new Vector3[points.Length + 2];

            Array.Copy(source, 0, outputs, 1, source.Length);

            outputs[0] = outputs[1] + outputs[1] - outputs[2];

            GameObject obj = new GameObject("Extra0");
            CatmullPathPoint cat = obj.AddComponent<CatmullPathPoint>();
            obj.transform.position = outputs[0];
            cat.PointType = CatmullPathPoint.eCatmullPointType.ePoint_ExtraPoint;

            outputs[outputs.Length - 1] = outputs[outputs.Length - 2] + outputs[outputs.Length - 2] - outputs[outputs.Length - 3];
            obj = new GameObject("ExtraEnd");
            cat = obj.AddComponent<CatmullPathPoint>();
            obj.transform.position = outputs[outputs.Length - 1];
            cat.PointType = CatmullPathPoint.eCatmullPointType.ePoint_ExtraPoint;
            return outputs;

        }
        bool m_bIsFirst = false;
        void Move()
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                fCurPercent += speed * Time.deltaTime;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                fCurPercent -= speed * Time.deltaTime;
                if (fCurPercent <= 0f)
                    fCurPercent = 0f;
            }
            per = fCurPercent % 1f;

            

            if (PathFinding.CheckRecalculatePath(CurRoute, per))
            {
                if (Area2.Length > 0 && !m_bIsFirst)
                {
                    m_bIsFirst = true;
                    PathFinding.RecalculatePath(ref CurRoute, CatmullPathPoint.GetVectorArray(Area2), ref fCurPercent);
                    per = fCurPercent % 1f;
                }
            }


            Vector3 pos = PathFinding.Interp(CurRoute, per);

            transform.position = Vector3.Lerp(transform.position, new Vector3(
                pos.x,
                transform.position.y,
                pos.z
                ), 10 * Time.deltaTime);
            //transform.position = ;

        }

        float fCurPercent = 0f;
        float per;
        bool bFirst = false;
        float speed = 0.4f;
        //int index = 2;          
        Vector3 Interp()      //working-V1
        {
            fCurPercent += speed * Time.deltaTime;
            per = fCurPercent % 1f;
            int numSections = CurRoute.Length - 3;
            int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);
            int index = numSections - 1;//至少要为剩下的路线留出4个点，否则曲线衔接会出问题。原理和catmull 的计算公式有关。
            if (currPt == index && !bFirst)
            {
                bFirst = true;
                //在这个地方可以进行添加点操作
                Vector3[] tmp = new Vector3[CurRoute.Length];
                Array.Copy(CurRoute, index, tmp, 0, CurRoute.Length - index - 1);
                for (int i = index - 1; i >= 0; i--)
                {
                    tmp[tmp.Length  - 1 - i - 1] = Area2[index - 1 - i].transform.position;
                }

                tmp[tmp.Length - 1] = tmp[tmp.Length - 2] + tmp[tmp.Length - 2] - tmp[tmp.Length - 3];
                Array.Copy(tmp, CurRoute, tmp.Length);
                currPt = 0;
                fCurPercent = per = 0f;
#if UNITY_EDITOR
                GameObject obj = new GameObject("ExtraLast");
                CatmullPathPoint cat = obj.AddComponent<CatmullPathPoint>();
                obj.transform.position = tmp[tmp.Length - 1];
                cat.PointType = CatmullPathPoint.eCatmullPointType.ePoint_ExtraPoint;
#endif

            }
            float u = per * (float)numSections - (float)currPt;

            Vector3 a = CurRoute[currPt];
            Vector3 b = CurRoute[currPt + 1];
            Vector3 c = CurRoute[currPt + 2];
            Vector3 d = CurRoute[currPt + 3];

            return .5f * (
                (-a + 3f * b - 3f * c + d) * (u * u * u)
                + (2f * a - 5f * b + 4f * c - d) * (u * u)
                + (-a + c) * u
                + 2f * b
            );
        }

        Vector3 oldp;
        Vector3 curp;
        //void OnDrawGizmos()
        //{
        //    if (null != CurRoute && CurRoute.Length > 2)
        //    {
        //        for (int i = 0; i < 20; i++ )
        //        {
        //            curp = Interp();

        //            Gizmos.color = Color.green;
        //            Gizmos.DrawLine(oldp, curp);

        //            oldp = curp;
        //        }

        //    }
        
        //}

        void Update()
        {
            Move();
        }
    }
}

//Vector3 Interp()
//{
//    fCurPercent += speed * Time.deltaTime;
//    per = fCurPercent % 1f;
//    int numSections = CurRoute.Length - 3;
//    int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);

//    if (currPt == numSections - 3 && !bFirst)                  //当前模块是倒数第3个模块 : 要保证在添加曲线的时候，后面至少还有四个点
//    {
//        float u1 = per * (float)numSections - (float)currPt;

//        bFirst = true;
//        Vector3[] tmpArea2 = new Vector3[Area2.Length];
//        for (int i = 0; i < Area2.Length; i++)
//        {
//            tmpArea2[i] = Area2[i].transform.position;
//        }
//        Vector3[] tmp = new Vector3[CurRoute.Length - currPt + tmpArea2.Length + 1];
//        Array.Copy(CurRoute, currPt, tmp, 0, CurRoute.Length - currPt);
//        Array.Copy(tmpArea2, 0, tmp, CurRoute.Length - currPt, tmpArea2.Length);
//        tmp[tmp.Length - 1] = tmp[tmp.Length - 2] + tmp[tmp.Length - 2] - tmp[tmp.Length - 3];
//        CurRoute = new Vector3[tmp.Length];
//        Array.Copy(tmp, CurRoute, tmp.Length);

//        numSections = CurRoute.Length - 3;
//        currPt = 0;//= Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);
//        fCurPercent = per = (u1 + (float)currPt) / (float)numSections;
//    }

//    float u = per * (float)numSections - (float)currPt;

//    Vector3 a = CurRoute[currPt];
//    Vector3 b = CurRoute[currPt + 1];
//    Vector3 c = CurRoute[currPt + 2];
//    Vector3 d = CurRoute[currPt + 3];

//    lastPt = currPt;

//    return .5f * (
//        (-a + 3f * b - 3f * c + d) * (u * u * u)
//        + (2f * a - 5f * b + 4f * c - d) * (u * u)
//        + (-a + c) * u
//        + 2f * b
//    );
//}