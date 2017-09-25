using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class CameraController : MonoBehaviour {

        #region 变量
        [SerializeField]
        private eCamMoveDir BirthMoveDir = eCamMoveDir.CamMove_Right;

        public float SUpSpeed = 5f;

        float SMoveSpeed = 4f;

        private Vector3 cammovevector = Vector3.zero;
        public Vector3 m_vCamMoveVector
        {
            get
            {
                return cammovevector;
            }
        }


        private eCamMoveDir cammovedir;                                                                                                                                                             // 当前的运动方向
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

        private BaseActor owner;
        public BaseActor Owner
        {
            get
            {
                return owner;
            }
        }

        private Vector3 targetplanenormal = Vector3.back;
        public Vector3 TargetPlaneNormal
        {
            get
            {
                return targetplanenormal;
            }
            set
            {
                if (value != targetplanenormal)
                    targetplanenormal = value;
            }
        }

        [HideInInspector]
        public Transform m_tTarget;                                                                                                                                                                                //目标对象

        [HideInInspector]        
        public Vector3[] m_vPoints = new Vector3[4];                                                                                                                                           //相机和目标平面的四个交点坐标
        [HideInInspector]
        public Dictionary<eCamFourCorner, Vector3> m_dCamDir = new Dictionary<eCamFourCorner, Vector3>();                                                      //相机视野四个角的方向向量
        
        [HideInInspector]
        public Dictionary<eTargetFourCorner, Vector3> m_dTargetCornerPoints = new Dictionary<eTargetFourCorner, Vector3>();                                   //目标视野边界顶点坐标          
        
        private Vector3 middlepoint;
        public Vector3 m_vMiddlePoint                                                                                                                                                                //相机朝向和目标平面的焦点.
        {
            get
            {
                return middlepoint;
            }
            set
            {
                if (value != middlepoint)
                    middlepoint = value;
            }
        }                                                                             
        float m_fCamDis = 0.5f;                                                                                                                                                                             //设定距离相机的距离<帮助确定四个方向的向量>

        float m_fHalfFOVRad;                                                                                                                                                                                //相机角度一半的弧度值

        float m_fAspect;                                                                                                                                                                                        //相机的宽高比

        float height, width;

        bool m_bRefreshCameraData;                                                                                                                                                                   //判定是否刷新相机数据
        public bool BRefreshCameraData                                                                                                                                                              //判定是否刷新相机数据
        {
            get
            {
                return m_bRefreshCameraData;
            }
            set
            {
                if (value != m_bRefreshCameraData)
                {

                    //if (m_bRefreshCameraData == true && value == false && Owner.PlayerMgr.IsJump() && CamMoveDir == eCamMoveDir.CamMove_Up)
                    //{
                       
                    //}

                    m_bRefreshCameraData = value;
                }
                   
            }
        }                                                                                                                                                                  

        #endregion


        void Awake()
        {
            m_fHalfFOVRad = Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad;

            m_fAspect = Camera.main.aspect;

            height = m_fCamDis * Mathf.Tan(m_fHalfFOVRad);

            width = height * m_fAspect;

            vLastPos = transform.position;

            vLastRot = transform.rotation.eulerAngles;
        }

        Vector3 vLastPos;
        Vector3 vLastRot;
        void DetectTransformChange()
        {


            if (vLastPos != transform.position || vLastRot != transform.rotation.eulerAngles)
            {
                BRefreshCameraData = true;                  //改变了相机的位置或者旋转
            }

            RefreshCamTargetBorderPoint();

            vLastPos = transform.position;
            vLastRot = transform.rotation.eulerAngles;
        }                                                                                                                                                        //检测相机的位置或者旋转是否发生了变化，如果发生变化，重新计算所有数据

        public void RefreshCamTargetBorderPoint()                                                                                                                                        //刷新相机到目标平面四个交点坐标, 目标自身边界顶点
        {

            if (!m_bRefreshCameraData)  //如果m_bRefreshCameraData = false，则不开启刷新相机数据
                return;
#if UNITY_EDITOR
            CalCamFourDir();

            for (eCamFourCorner type = eCamFourCorner.CamCorner_UpperLeft; type < eCamFourCorner.CamCorner_Size; type++)
            {
                m_vPoints[(int)type] = CalBordPoint(type);
            }
#endif
            //calculate middle point 
            CalMiddleAtTargetPlane();

            //calculate target's border coordinates.
            CalTargetFourCorner();


            m_bRefreshCameraData = false; //处理完相机数据，关闭处理相机数据开关
        }

        void CalTargetFourCorner()                                                                                                                                                                  //计算目标4个corner坐标 
        {
            Vector3 tmp;
            //Target Left
            tmp = transform.position - transform.right * width;
            //tmp += transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            tmp = GetTargetCornerPoint(tmp);
            //tmp = new Vector3(tmp.x, m_tTarget.position.y, tmp.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Left, tmp);

            //Target Right, 
            tmp = transform.position + transform.right * width;
            //tmp += transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            tmp = GetTargetCornerPoint(tmp);
            // tmp = new Vector3(tmp.x, m_tTarget.position.y, tmp.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Right, tmp);

            //Target Up
            //tmp = transform.position + transform.right * width;
            tmp = transform.position;
            tmp += transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            tmp = GetTargetCornerPoint(tmp);
            //tmp = new Vector3(m_tTarget.position.x, tmp.y, tmp.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Up, tmp);

            //Target Down
            tmp = transform.position;
            tmp -= transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            tmp = GetTargetCornerPoint(tmp);
            //tmp = new Vector3(m_tTarget.position.x, tmp.y, tmp.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Down, tmp);
        }
   
        void CalculateTargetCorner(eTargetFourCorner type, Vector3 pos)
        {
            if (!m_dTargetCornerPoints.ContainsKey(type))
                m_dTargetCornerPoints.Add(type, pos);
            else
                m_dTargetCornerPoints[type] = pos;
        }
        
        Vector3 GetTargetCornerPoint(Vector3 dir)
        {

             float t = (m_tTarget.position.z - transform.position.z) / dir.z;

             Vector3 corner = transform.position + t * dir;

             return corner;
        }

        void CalCamFourDir()                                        //确定相机的四个视野方向                                                                                                                                                                                                                         
        {
            Vector3 tmp;
            //UpperLeft
            tmp = transform.position - transform.right * width;
            tmp += transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            CalculateCornerDir(eCamFourCorner.CamCorner_UpperLeft, tmp);

            //UpdateRight
            tmp = transform.position + transform.right * width;
            tmp += transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            CalculateCornerDir(eCamFourCorner.CamCorner_UpperRight, tmp);

            //DownLeft
            tmp = transform.position - transform.right * width;
            tmp -= transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            CalculateCornerDir(eCamFourCorner.CamCorner_DownLeft, tmp);

            //DownRight
            tmp = transform.position + transform.right * width;
            tmp -= transform.up * height;
            tmp += transform.forward * m_fCamDis;
            tmp = (tmp - transform.position).normalized;
            CalculateCornerDir(eCamFourCorner.CamCorner_DownRight, tmp);
        }

        Vector3 CalBordPoint(eCamFourCorner type)                                                                                                                                        //计算相机指定距离视野边界顶点坐标
        {

            float t = 0f;

            //相机视野UpperLeft在目标平面的交点坐标

            //Vector3 vTargetPlaneInterPoint = transform.position + t * m_dCamDir[type];

            //目标平面向量
            //Vector3 vTargetPlane = vTargetPlaneInterPoint - m_tTarget.position;

            // (0, 0, -1) dot (vTargetPlane) = 0;

            //(vTargetPlaneInterPoint - m_tTarget.position).z * (-1) = 0

            //vTargetPlaneInterPoint.z = m_tTarget.position.z

            //(transform.position + t * m_dCamDir[eCamFourCorner.CamCorner_UpperLeft]).z = m_tTarget.position.z

            t = (m_tTarget.position.z - transform.position.z) / m_dCamDir[type].z;


            Vector3 corner = transform.position + t * m_dCamDir[type];

            return corner;
        }

        void CalculateCornerDir(eCamFourCorner type, Vector3 pos)
        {
            if (!m_dCamDir.ContainsKey(type))
                m_dCamDir.Add(type, pos);
            else
                m_dCamDir[type] = pos;
        }

        Vector3 CalMiddleAtTargetPlane()                                                                                                                                                        //计算相机朝向和目标平面的交点坐标.
        {

            float t = (m_tTarget.position.z - transform.position.z) / transform.forward.z;

            m_vMiddlePoint = transform.position + t * transform.forward;

            //if (Owner.PlayerMgr.IsJump() && CamMoveDir == eCamMoveDir.CamMove_Up)
            //{
            //    m_vMiddlePoint = new Vector3(
            //              m_vMiddlePoint.x,
            //              Owner.PlayerMgr.FPlayerJumpBeginYPos + (m_dTargetCornerPoints[eTargetFourCorner.TargetCorner_Up].y - Owner.PlayerMgr.FPlayerJumpBeginYPos) * 0.5f,
            //              m_vMiddlePoint.z
            //              );
            //}
            return m_vMiddlePoint;
        }
        
        void Update()
        {

            if (!Owner)
                return;

            DetectTransformChange();

            switch (cammovedir)
            {
                case eCamMoveDir.CamMove_Right:
                    {
                        if (Owner.ActorTrans.transform.position.x > m_vMiddlePoint.x)
                        {
                            transform.Translate(Vector3.right * SMoveSpeed * Time.deltaTime, Space.World);
                        }
                        break;
                    }
                case eCamMoveDir.CamMove_Left:
                    {
                        if (Owner.ActorTrans.transform.position.x < m_vMiddlePoint.x)
                        {
                            transform.Translate(Vector3.left * SMoveSpeed * Time.deltaTime, Space.World);
                        }
                        break;
                    }
                case eCamMoveDir.CamMove_Up:
                    {
                        if (Owner.ActorTrans.transform.position.y > m_vMiddlePoint.y)
                        {
                            transform.Translate(Vector3.up * SUpSpeed * Time.deltaTime, Space.World);
                        }
                        break;
                    }

            }
        }
        
        public void OnStart(BaseActor _owner)
        {
            owner = _owner;

            SMoveSpeed = owner.BaseAtt.RoleInfo.RoleMoveSpeed;

            CamMoveDir = BirthMoveDir;

            m_tTarget = owner.ActorTrans.transform;                                                                                                                                                                                //确定目标

            BRefreshCameraData = true;

            RefreshCamTargetBorderPoint();

        }
        
}   
