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


    private Vector3 m_vLastTransformRotation;

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
        m_vLastTransformRotation = transform.rotation.eulerAngles;
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
    ///

    public Vector3 GetCameraMajorMiddlePoint()
    {

        //相机坐标
        Vector3 vCamPos = transform.position;

        //相机方向向量
        Vector3 vCamDir = transform.forward;

        //主角平面法向量
        Vector3 vPlaneNormal = Vector3.back;

        //(vCamPos + t * vCamDir - Owner.ActorTrans.position).z * (-1) = 0f;

        //Owner.ActorTrans.position = vCamPos + t * vCamDir;

        float t = (Owner.ActorTrans.position.z - vCamPos.z) / vCamDir.z;

        m_vMiddlePoint = new Vector3(
            vCamPos.x + vCamDir.x * t,
            vCamPos.y + vCamDir.y * t,
            vCamPos.z + vCamDir.z * t
            );

        return m_vMiddlePoint;
    }

//    public Vector3 GetCameraMajorMiddlePoint()
//    {

//        float fMiddleX, fMiddleY;

//        float fZCamToMajor = Owner.ActorTrans.position.z - transform.position.z;//相机到主角在Z轴方向的距离

//        Vector3 camDir = new Vector3(transform.forward.x, 0f, transform.forward.z);//获取相机的方向向量 -> 经过测试通过
//        float CosBetweenCamAndForward = Vector3.Dot(camDir, Vector3.forward);//获取相机方向和Z轴正方向的夹角余弦值
//        m_fZLineLength  = fZCamToMajor / CosBetweenCamAndForward;//获得相机到主角线段的线段长度

//        Vector3 camMajorHeight = new Vector3(
//        transform.position.x,
//        Owner.ActorTrans.position.y,
//        transform.position.z);

//        //获取相机正方向和主角线段的交点坐标
//        Vector3 vCamMiddlePoint = transform.position + (new Vector3(transform.forward.x, 0f, transform.forward.z)) * (m_fZLineLength);

//        fMiddleX = vCamMiddlePoint.x;

//        #region 计算Y轴方向的中点坐标
////        //if (m_vLastTransformRotation.y == transform.rotation.eulerAngles.y && m_vLastTransformRotation.x != transform.rotation.eulerAngles.x)
////        {
////            //获取0点位置, Z轴坐标和主角一致， X轴坐标和主角一致。Y是变化需要计算的
////            camDir = new Vector3(0f, transform.forward.y, transform.forward.z);
////            CosBetweenCamAndForward = Vector3.Dot(camDir, Vector3.forward);
////            float RadiusCamRotateX = Mathf.Acos(CosBetweenCamAndForward);
////#if UNITY_EDITOR
////            float DegreeCamRotateX = RadiusCamRotateX * Mathf.Rad2Deg;
////#endif
////            float camY = transform.position.y;                                                                                                                                           //相机的Y轴坐标

////            float zeroPointY = 0f;                                                                                                                                                              //0点Y轴坐标值

////            float YDisBetZeroAndCam = fZCamToMajor * Mathf.Tan(RadiusCamRotateX);                                                                         //相机和zero点在Y轴的距离
////            if (YDisBetZeroAndCam == float.PositiveInfinity)
////                YDisBetZeroAndCam = 0f;

////            if (transform.forward.y > 0f)
////            {
////                zeroPointY = camY + YDisBetZeroAndCam;
////            }
////            else
////            {
////                zeroPointY = camY - YDisBetZeroAndCam;
////            }

////            fMiddleY = zeroPointY;



////            //float FirstPointY = 0f;                                                                                                                                                                 //1点Y轴坐标值

////            //float DegreeFirstPointRotate = RadiusCamRotateX * Mathf.Rad2Deg - Camera.main.fieldOfView * 0.5f;                                      //1点围绕X轴旋转的角度                               

////            //float YDisBetFirstAndCam = fZCamToMajor / Mathf.Tan(DegreeFirstPointRotate * Mathf.Deg2Rad);                                                                         //相机和First点在Y轴的距离

////            //FirstPointY = zeroPointY + (YDisBetZeroAndCam - YDisBetFirstAndCam);

////            //计算上边界中点坐标
////        }

////        m_vLastTransformRotation = transform.rotation.eulerAngles;
//        #endregion

//        //m_vMiddlePoint = new Vector3(fMiddleX, fMiddleY, Owner.ActorTrans.position.z);
//        return m_vMiddlePoint;//将坐标数值返回
//    }



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
    float m_fZLineLength;//获取相机在XZ轴坐标系下到达主角线段的长度<绕Y轴旋转>
    public float ZLineLength
    {
        get
        {
            return m_fZLineLength;
        }
    }

    //float m_fZUpdownLineLength; //获取相机在YZ轴坐标系下到达主角线段的长度<绕X轴旋转>
    //public float ZUpdownLineLength
    //{
    //    get
    //    {
    //        return m_fZUpdownLineLength;
    //    }
    //}

    #endregion

}   
