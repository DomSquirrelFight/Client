using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class BezierLine : MonoBehaviour {
    bool IsCreateLine = false;
    public  static Vector3[] m_vBezierPoints;
    public static Vector3[] GetBezierPoints(Transform[] points)
    {
        m_vBezierPoints = new Vector3[points.Length];
      
        for(int i=0;i<points.Length;i++)
        {
            m_vBezierPoints[i] = points[i].position;
           
        }
        EnforceMode(1, points.Length, eBezierLineConstrainedMode.Mirror);
        return m_vBezierPoints;
    }

    #region 属性
    //索引器
    public Vector3 this[int index]
    {
        get
        {
            return m_vBezierPoints[index];
        }
        set
        {
            if (value != m_vBezierPoints[index])
                m_vBezierPoints[index] = value;
        }
    }
    //点的数量
    public  int PointNum
    {
        get
        {
            return m_vBezierPoints.Length;
        }
    }
    public  int CurveNum
    {
        get
        {
            return (PointNum - 1) / 3;
        }
    }
    #endregion

    //计算切线朝向
    public static  Vector3 GetDirection(float t,int num)
    {
        int i;
        if (t >= 1.0f)
        {
            t = 1.0f;
            i = num - 4;
        }
        else
        {
            //曲线个数
            t *=((num-1)/3);
            i = (int)t;
            t = t - i;
            i *= 3;
        }
        Vector3 p0 = m_vBezierPoints[i];
        Vector3 p1 = m_vBezierPoints[i+1];
        Vector3 p2 = m_vBezierPoints[i+2];
        Vector3 p3 = m_vBezierPoints[i+3];

        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }

    //根据进度获取点
    public static  Vector3 GwtMove(float t,int num)
    {
        int i;
        if (t >= 1.0f)
        {
            t = 1.0f;
            i = num - 4;
        }
        else
        {
            t *= ((num - 1) / 3);
            i = (int)t;
            t = t - i;
            i *= 3;
        }
        Vector3 p0 = m_vBezierPoints[i];
        Vector3 p1 = m_vBezierPoints[i + 1];
        Vector3 p2 = m_vBezierPoints[i + 2];
        Vector3 p3 = m_vBezierPoints[i + 3];
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t * p3;

    }

    //添加点的限制模式

    public static void EnforceMode(int index,int PointNum,eBezierLineConstrainedMode eMode)
    {
        if (index < 0 || index > PointNum)
            return;

        int modeIndex = (index + 1) / 3;
        if (modeIndex == 0 )
            return;

        if (eMode == eBezierLineConstrainedMode.Free)
            return;
        else if (eMode == eBezierLineConstrainedMode.Mirror)
        {
            int middleIndex = modeIndex * 3;
            Vector3 middlePoint, fixedPoint, enforcedPoint;
            int fixedIndex, enforcedIndex;
            middlePoint = m_vBezierPoints[middleIndex];
            if (index > middleIndex)
            {

                fixedIndex = middleIndex + 1;
                enforcedIndex = middleIndex - 1;
            }
            else
            {
                fixedIndex = middleIndex - 1;
                enforcedIndex = middleIndex + 1;
            }

            fixedPoint = m_vBezierPoints[fixedIndex];
            enforcedPoint = middlePoint + (middlePoint - fixedPoint).normalized * Vector3.Distance(middlePoint, fixedPoint);
            enforcedPoint = middlePoint + (middlePoint - fixedPoint).normalized;
            m_vBezierPoints[enforcedIndex] = enforcedPoint;
        }
    }

}
