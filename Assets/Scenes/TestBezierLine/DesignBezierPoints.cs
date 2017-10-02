using UnityEngine;
using System;
using AttTypeDefine;

public class DesignBezierPoints : MonoBehaviour {

    #region 成员变量
    [SerializeField]
    public Vector3[] m_vPoints;

    BezierLine bl;
#endregion

    #region 添加曲线
    public void AddCurve()
    {
        Vector3 point = m_vPoints[PointNum - 1];
        Array.Resize(ref m_vPoints, PointNum + 3);
        point.x += 1;
        m_vPoints[PointNum - 3].x = point.x;
        point.x += 1;
        m_vPoints[PointNum - 2].x = point.x;
        point.x += 1;
        m_vPoints[PointNum - 1].x = point.x;
        //在添加曲线的时候，增加mode数组大小，并给他初始化。
        Array.Resize(ref m_eMode, m_eMode.Length + 1);
        m_eMode[m_eMode.Length - 1] = eBezierLineConstrainedMode.Free;
    }
#endregion

    #region 属性索引器
    public Vector3 this[int index]
    {
        get
        {
            return m_vPoints[index];
        }
        set
        {
            if (value != m_vPoints[index])
                m_vPoints[index] = value;
        }
    }
    public int CurveNum
    {
        get
        {
            return (PointNum - 1) / 3;
        }
    }
    public int PointNum
    {
        get
        {
            return m_vPoints.Length;
        }
    }
    #endregion

    #region 系统接口
    void Start()
    {
        bl = gameObject.AddComponent<BezierLine>();
    }
    private void Reset()
    {
        m_vPoints = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(2, 0, 0),
            new Vector3(3, 0, 0)
        };
        m_eMode = new eBezierLineConstrainedMode[] {
            eBezierLineConstrainedMode.Free,
            eBezierLineConstrainedMode.Free
        };
    }

    #endregion

    #region 添加点的限制模式
    [SerializeField]
    eBezierLineConstrainedMode[] m_eMode;

    //根据点的index获取对应的mode数组中的mode类型
    public eBezierLineConstrainedMode GetModeByPointIndex(int index)
    {
        return m_eMode[(index + 1) / 3];
    }

    public void SetBezierLineConstrainedMode(int index, eBezierLineConstrainedMode mode)
    {
        m_eMode[(index + 1) / 3] = mode;
        EnforceMode(index);
    }
    //添加点的限制模式
    public void EnforceMode(int index)
    {
        if (index < 0 || index > PointNum)
            return;

        int modeIndex = (index + 1) / 3;
        if (modeIndex == 0 || modeIndex == m_eMode.Length - 1)
            return;

        if (m_eMode[modeIndex] == eBezierLineConstrainedMode.Free)
            return;
        else if (m_eMode[modeIndex] == eBezierLineConstrainedMode.Mirror)
        {
            int middleIndex = modeIndex * 3;
            Vector3 middlePoint, fixedPoint, enforcedPoint;
            int fixedIndex, enforcedIndex;
            middlePoint = m_vPoints[middleIndex];
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

            fixedPoint = m_vPoints[fixedIndex];
            enforcedPoint = middlePoint + (middlePoint - fixedPoint).normalized * Vector3.Distance(middlePoint, fixedPoint);
            // enforcedPoint = middlePoint + (middlePoint - fixedPoint).normalized;
            m_vPoints[enforcedIndex] = enforcedPoint;
        }


    }
    #endregion

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(m_vPoints[m_vPoints.Length - 1], 0.25f);
        Gizmos.DrawSphere(m_vPoints[0], 0.25f);
    }
}
