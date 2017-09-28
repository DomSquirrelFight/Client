#region namespace
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#endregion

namespace Assets.Scenes.TestCatmull
{

    public class Control : MonoBehaviour
    {

        public CatmullPathPoint[] Area1;
        public CatmullPathPoint[] Area2;

        Vector3[] CurRoute;

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

        void Update()
        {

            //CalMoveInput();

            Move();

        }

        float fInputX = 1f;
        float speed = 0.2f;
        float percent = 0f;
        float realper = 0f;
        void CalMoveInput()
        {
            //fInputX = Input.GetAxis("Horizontal");
            if (fInputX > 0f)
            {
                percent += speed * Time.deltaTime;
            }
            else if (fInputX < 0f)
            {
                percent -= speed * Time.deltaTime;
            }
        }

        void Move()
        {
            //if (fInputX != 0f)
            //{
            //    realper = percent % 1f;
             
            //}

            Vector3 pos = Interp();
            transform.position = new Vector3(
                pos.x,
                transform.position.y,
                pos.z
                );

        }

        float fCurPercent = 0f;
        float per;
        bool bFirst = false;
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

        int index = 2;          //至少要为剩下的路线留出3个点，否则曲线衔接会出问题。
        Vector3 Interp()      //working-V1
        {
            fCurPercent += speed * Time.deltaTime;
            per = fCurPercent % 1f;
            int numSections = CurRoute.Length - 3;
            int currPt = Mathf.Min(Mathf.FloorToInt(per * (float)numSections), numSections - 1);

            if (currPt == index && !bFirst)
            {
                bFirst = true;
                //在这个地方可以进行添加点操作
                Vector3[] tmp = new Vector3[CurRoute.Length];
                Array.Copy(CurRoute, index, tmp, 0, CurRoute.Length - index - 1);
                for (int i = index - 1; i >= 0; i--)
                {
                    tmp[tmp.Length - index - 1 - i] = Area2[index - 1 - i].transform.position;
                }

                tmp[tmp.Length - index] = tmp[tmp.Length - index - 1] + tmp[tmp.Length - index - 1] - tmp[tmp.Length - index - 2];
                Array.Copy(tmp, CurRoute, tmp.Length);
                currPt = 0;
                fCurPercent = per = 0f;
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
    
    }
}

