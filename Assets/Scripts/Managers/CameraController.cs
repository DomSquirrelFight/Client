using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class CameraController : MonoBehaviour {

    [SerializeField]
    private eCamMoveDir BirthMoveDir = eCamMoveDir.CamMove_Right;

    private Vector3 cammovevector = Vector3.zero;
    public Vector3 m_vCamMoveVector
    {
        get
        {
            return cammovevector;
        }
    }
   
    #region 当前的运动方向
    private eCamMoveDir cammovedir;
    public eCamMoveDir CamMoveDir
    {
        get
        {
            return cammovedir;
        }
        set
        {
            if (value != cammovedir)
            {
                cammovedir = value;
                switch (cammovedir)
                {
                    case eCamMoveDir.CamMove_Left:
                        {
                            cammovevector = Vector3.left;
                            break;
                        }
                    case eCamMoveDir.CamMove_Right:
                        {
                            cammovevector = Vector3.right;
                            break;
                        }
                    case eCamMoveDir.CamMove_Up:
                        {
                            cammovevector = Vector3.up;
                            break;
                        }
                    case eCamMoveDir.CamMove_Down:
                        {
                            cammovevector = Vector3.down;
                            break;
                        }

                }
            }
               
        }
    }
    #endregion

    private BaseActor owner;
    public BaseActor Owner
    {
        get
        {
            return owner;
        }
    }

    void Update()
    {
        switch (cammovedir)
        {
            case eCamMoveDir.CamMove_Right:
                {
                    if (Owner.ActorTrans.transform.position.x > m_vMiddlePoint.x)
                    {
                        transform.Translate(Vector3.right * 3f * Time.deltaTime, Space.World);
                        GetCameraMajorMiddlePoint();//获取中点坐标
                        GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Left, m_fZLineLength);//获取左边框坐标
                    }
                    break;
                }
            case eCamMoveDir.CamMove_Left:{
                if (Owner.ActorTrans.transform.position.x < m_vMiddlePoint.x)
                {
                    transform.Translate(Vector3.left * 3f * Time.deltaTime, Space.World);
                    GetCameraMajorMiddlePoint();//获取中点坐标
                    GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Right, m_fZLineLength);//获取左边框坐标
                }
                break;
            }
        }
    }

    public void OnStart(BaseActor _owner)
    {
        owner = _owner;
        CamMoveDir = BirthMoveDir;
        CalculateCamera();
    }

    public void CalculateCamera()
    {
        GetCameraMajorMiddlePoint();//获取中点坐标
        GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Left, m_fZLineLength);//获取左边框坐标
        GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Right, m_fZLineLength);//获取右边框坐标
    }
    
    /// <summary>
    /// 获取相机在主角线段的垂直方向和边框的交点坐标
    /// </summary>
    /// <param name="side"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    Vector3 GetCameraBorderPoint(eCameraBorderSide side, float length/*相机到指定点在正方向上的距离*/)
    {
        float halfFOV = Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad;
        float aspect = Camera.main.aspect;

        float height = length * Mathf.Tan(halfFOV);
        float width = height * aspect;

        Vector3 camMajorHeight = new Vector3(
            transform.position.x,
            Owner.ActorTrans.position.y,
            transform.position.z);

        Vector3 point = Vector3.zero;
        switch (side)
        {
            case eCameraBorderSide.CameraSide_Left:
                {
                    point = camMajorHeight - transform.right * width;
                    point += transform.forward * length;
                    break;
                }
            case eCameraBorderSide.CameraSide_Right:
                {
                    point = camMajorHeight + transform.right * width;
                    point += transform.forward * length;
                    break;
                }
        }

        return point;
    }

    /// <summary>
    /// 获取相机边框到主角线段的交点坐标
    /// </summary>
    /// <param name="side">确定相机边框</param>
    /// <param name="vSide">相机在主角线段的垂直方向和边框的交点坐标</param>
    /// <returns></returns>
    public Vector3 GetCameraMajorBorderPoint(eCameraBorderSide side,float length/*相机到指定点在正方向上的距离*/)
    {

        Vector3 vSide = GetCameraBorderPoint(side, length);

        Vector3 x = Vector3.zero;
        float k1 = Vector3.forward.z / Vector3.forward.x;//主角线段斜率
        float k2 = (vSide.z - transform.position.z) / (vSide.x - transform.position.x);//相机视野左边框斜率
        float d = transform.position.z - k2 * transform.position.x;//相机视野左边框截距
        float fx = (Owner.ActorTrans.position.z - d) / k2;//获取主角线段和leftline交点的X值
        Vector3 vecSide = new Vector3(fx, Owner.ActorTrans.position.y, Owner.ActorTrans.position.z);//确定leftline.x

        switch (side)
        {
            case eCameraBorderSide.CameraSide_Left:
                {
                    m_vLeftPoint = vecSide;
                    break;
                }
            case eCameraBorderSide.CameraSide_Right:
                {
                    m_vRightPoint = vecSide;
                    break;
                }
        }

        return vecSide;
    }

    /// <summary>
    /// 获取相机到主角线段的交点坐标
    /// </summary>
    /// <param name="fZLineLength">相机到主角线段的距离</param>
    /// <returns></returns>
    public Vector3 GetCameraMajorMiddlePoint()
    {

        float fZCamToMajor = Owner.ActorTrans.position.z - transform.position.z;//相机到主角在Z轴方向的距离

        Vector3 camDir = new Vector3(transform.forward.x, 0f, transform.forward.z);//获取相机的方向向量 -> 经过测试通过
        float CosBetweenCamAndForward = Vector3.Dot(camDir, Vector3.forward);//获取相机方向和Z轴正方向的夹角余弦值
        m_fZLineLength  = fZCamToMajor / CosBetweenCamAndForward;//获得相机到主角线段的线段长度

        Vector3 camMajorHeight = new Vector3(
        transform.position.x,
        Owner.ActorTrans.position.y,
        transform.position.z);

        //获取相机正方向和主角线段的交点坐标
        Vector3 vCamMiddlePoint = camMajorHeight + (new Vector3(transform.forward.x, 0f, transform.forward.z)) * (m_fZLineLength);

        m_vMiddlePoint = vCamMiddlePoint;

        return vCamMiddlePoint;//将坐标数值返回
    }

    #region 相机变量保存
    Vector3 m_vMiddlePoint;//相机在主角线段的交点坐标
    Vector3 m_vLeftPoint;//相机左边框和主角线段的交点坐标
    public Vector3 LeftPoint
    {
        get
        {
            return m_vLeftPoint;
        }
    }
    Vector3 m_vRightPoint;//相机右边框和主角线段的交点坐标
    public Vector3 RightPoint
    {
        get
        {
            return m_vRightPoint;
        }
    }
    float m_fZLineLength;//获取相机到主角线段长度
    public float ZLineLength
    {
        get
        {
            return m_fZLineLength;
        }
    }
    #endregion

}   
