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
    GameObject Owner;
    //切线，朝向
    Vector3 dir;
    string LinePath;
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
    public void RotatePlayerAlongBezier(string path, GameObject owner, float m_Dir, float speed)//Vector2 m_vInput,
    {
        Owner = owner;
        ResetPath(path);
        //Debug.Log(PathPercent);
        if (PathPercent >= 1)
            return;
        
        //ArrtTPoints = InArrtTPoints;
        Length = speed;

        //初始化点
        //GetBezierPoints(ArrtTPoints);
        CaculatePercent(m_Dir);
        dir = GetVelocity(PathPercent);
        CaculateDir();
        PlayerMove();
    }

    #endregion

    #region 初始化路线
    bool IsHavedPath = false;
    GameObject Lines;
    Vector3 m_oFinalPos;
    void ResetPath(string path)
    {
   
        //给路线创建一个父级，统一管理路线
        if (!IsHavedPath)
        {
            Lines = new GameObject("Lines");
            Lines.transform.position = Vector3.zero;
            IsHavedPath = true;
        }
        if (path != LinePath || LinePath == null)
        {
            PathPercent = 0;
            LinePath = path;
            //加载路线，进行初始化
            GameObject line = Instantiate(Resources.Load(LinePath)) as GameObject;
             line.transform.parent = Lines.transform;
            //获得路线上所有的点
            DesignBezierPath dbp = line.GetComponent<DesignBezierPath>();
            m_vBezierPoints = new Vector3[dbp.PointNum];
            Debug.Log(dbp.m_vPoints[0]);
            for(int i=0;i<dbp.m_vPoints.Length;i++)
            {
                m_vBezierPoints[i] = dbp.transform.TransformPoint(dbp.m_vPoints[i]);
            }
            Owner.transform.position = m_oFinalPos;
        }
    }

    #endregion

    #region 初始化点
    //public Vector3[] GetBezierPoints(Transform[] points)
    //{
    //    m_vBezierPoints = new Vector3[points.Length];

    //    for (int i = 0; i < points.Length; i++)
    //    {
    //        m_vBezierPoints[i] = points[i].position;
    //        //EnforceMode(i, points.Length, eBezierLineConstrainedMode.Mirror);
    //    }
    //    //EnforceMode(1, points.Length - 1, eBezierLineConstrainedMode.Mirror);
    //    return m_vBezierPoints;
    //}
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
            {

                if (index % 3 == 0)
                {
                    Vector3 delta = m_vBezierPoints[index] - value;
                    if (index > 0 && index < m_vBezierPoints.Length - 1)
                    {
                        m_vBezierPoints[index + 1] += delta;
                        m_vBezierPoints[index - 1] += delta;
                    }
                }

                m_vBezierPoints[index] = value;
                
            }

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

    #region 进度值计算
    void CaculatePercent(float direction)
    {
        if (dir.magnitude == 0)
            return;
        if (direction > 0f)
        {
            PathPercent = PathPercent + (Length * Time.deltaTime)/dir.magnitude;
        }
        else if (direction < 0f)
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
        Owner.transform.position = new Vector3(
            floorPosition.x,
            Owner.transform.position.y,
            floorPosition.z
            );
    }
    #endregion

    #region 朝向控制
    void CaculateDir()
    {
        if (PathPercent - LookAheadAmount >= float.Epsilon && PathPercent + LookAheadAmount <= 1f)
        {
            Vector3 m_vOwnerPosition = Owner.transform.position;
            if (m_vInputMove.x > 0f)
            {
                Owner.transform.LookAt2D(m_vOwnerPosition + dir.normalized);
            }
            else if (m_vInputMove.x < 0f)
            {
                Owner.transform.LookAt2D(m_vOwnerPosition - dir.normalized);
            }
        }
    }
#endregion

}
