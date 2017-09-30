using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class BezierLine : MonoBehaviour {

    #region 成员变量
    public Vector3[] m_vBezierPoints;
    float PathPercent;
    float Length;
    float LookAheadAmount;
    Vector3 floorPosition;



    Vector2 m_vInputMove;

    Transform[] ArrtTPoints;
    BaseActor Owner;
    //切线，朝向
    Vector3 dir;

    #endregion

    #region 系统接口
    private void Start()
    {
        PathPercent = 0f;
        Length = 2f;
        LookAheadAmount = 0.01f;
    }
    #endregion


    #region 外部调用接口
    public void RotatePlayerAlongBezier(Transform[] InArrtTPoints, BaseActor owner, Vector2 m_vInput)
    {
        //Debug.Log(PathPercent);
        if (PathPercent >= 1)
            return;
        m_vInputMove = m_vInput;
        ArrtTPoints = InArrtTPoints;
        Owner = owner;
        //初始化点
        GetBezierPoints(ArrtTPoints);
        CaculatePercent();
        dir = GetVelocity(PathPercent);
        CaculateDir();
        PlayerMove();
        

    }
    #endregion

    #region 初始化点
    public Vector3[] GetBezierPoints(Transform[] points)
    {
        m_vBezierPoints = new Vector3[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            m_vBezierPoints[i] = points[i].position;
            //EnforceMode(i, points.Length, eBezierLineConstrainedMode.Mirror);
        }
        //EnforceMode(1, points.Length - 1, eBezierLineConstrainedMode.Mirror);
        return m_vBezierPoints;
    }
    #endregion

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

    #region 切线斜率
    //计算切线朝向
    public  Vector3 GetVelocity(float t)
    {
        int i;
        if (t >= 1.0f)
        {
            t = 1.0f;
            i = PointNum - 4;
        }
        else
        {
            //曲线个数
            t *= CurveNum;
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
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }
    #endregion

    #region 进度点
    //根据进度获取点
    public  Vector3 GwtMove(float t)
    {
        int i;
        if (t >= 1.0f)
        {
            t = 1.0f;
            i = PointNum - 4;
        }
        else
        {
            t *=CurveNum;
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
    #endregion

    #region 添加点的限制模式
    //添加点的限制模式
      void EnforceMode(int index, int PointNum, eBezierLineConstrainedMode eMode)
    {
        //只有一条曲线的时候直接返回
        if (PointNum <= 4)
            return;
        if (index <= 0 || index >=  PointNum-1)
            return;
        int modeIndex = (index + 1) / 3;
        if (modeIndex == 0)
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
    #endregion

    #region 进度值计算
    void CaculatePercent()
    {
        if (dir.magnitude == 0)
            return;
        if (m_vInputMove.x > 0f)
        {
            PathPercent = PathPercent + (Length * Time.deltaTime)/dir.magnitude;
        }
        else if (m_vInputMove.x < 0f)
        {
            PathPercent = PathPercent - (Length * Time.deltaTime) / dir.magnitude;
        }


    }
    #endregion

    #region 角色移动
    void PlayerMove()
    {
        floorPosition = GwtMove(PathPercent);
        //Owner.ActorTrans.position = Vector3.Lerp(Owner.ActorTrans.position, new Vector3(
        //    floorPosition.x,
        //    Owner.ActorTrans.position.y,
        //    floorPosition.z
        //    ), SMoveSpeed*Time.deltaTime );
        Owner.ActorTrans.position = new Vector3(
            floorPosition.x,
            Owner.ActorTrans.position.y,
            floorPosition.z
            );
    }
    #endregion

    #region 朝向控制
    void CaculateDir()
    {
        if (PathPercent - LookAheadAmount >= float.Epsilon && PathPercent + LookAheadAmount <= 1f)
        {
            Vector3 m_vOwnerPosition = Owner.ActorTrans.position;
            if (m_vInputMove.x > 0f)
            {
                Owner.ActorTrans.LookAt2D(m_vOwnerPosition + dir.normalized);
            }
            else if (m_vInputMove.x < 0f)
            {
                Owner.ActorTrans.LookAt2D(m_vOwnerPosition - dir.normalized);
            }
        }
    }
#endregion

}
