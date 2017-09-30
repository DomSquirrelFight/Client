using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.Action;
public class CameraController : MonoBehaviour
{
   
        #region 变量

        private Transform caminsttrans;
        public Transform CamInstTrans
        {
            get
            {
                if (null == caminsttrans)
                {
                    caminsttrans = Camera.main.transform;
                }
                return caminsttrans;
            }
        }

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

        //[HideInInspector]
        public Dictionary<eTargetFourCorner, Vector3> m_dTargetCornerPoints = new Dictionary<eTargetFourCorner, Vector3>();                                   //目标视野边界顶点坐标          


        #endregion
        
        #region 回收所有数据

        void ClearAllData()
        {
            ClearCamStates();
        }
        #endregion

        #region 相机状态管理

       //------------------------------------------------------------------------相机当前状态索引值----------------------------------------------------------------//
        private int m_curindex = 0;
        public int CurCamStateIndex
        {
            get
            {
                return m_curindex;
            }
        }
        //-----------------------------------------------------------------------相机当前状态索引值----------------------------------------------------------------//


        //------------------------------------------------------------------------相机所有状态----------------------------------------------------------------//
        [HideInInspector]
        public bool BShowAllCamStates;
        [HideInInspector]
        public int StateNumber;
        [HideInInspector]
        public CameraBaseAction[] CamActions;
        //------------------------------------------------------------------------相机所有状态----------------------------------------------------------------//


        //------------------------------------------------------------------------保存相机当前状态----------------------------------------------------------------//
        CameraBaseAction curcamaction;
        public CameraBaseAction CurCamAction
        {
            get
            {
                return curcamaction;
            }
        }
        //------------------------------------------------------------------------保存相机当前状态----------------------------------------------------------------//
        
        void InitializeCamStates()              //根据用户输入，初始化所有相机状态
        {
            for (int i = 0; i < CamActions.Length; i++)
            {
                CamActions[i].InitStateData(this, i, NotifyCamCtrlStateOver);
            }
            curcamaction = CamActions[m_curindex];      //赋值当前相机行为
        }

        void ClearCamStates()
        {
            //dic.Clear(); dic = null;
        }               //清理相机申请的内存数据

        void BeginCurCamAction()           //开始当前的行动
        {
            curcamaction.OnStart();
        }
        void NotifyCamCtrlStateOver(int index)  //结束当前行动，并且开启新的行动
        {
            if (m_curindex == index)
            {
                //get new state。
                m_curindex++;
                if (m_curindex < CamActions.Length)
                {
                    curcamaction = CamActions[m_curindex];      //赋值当前相机行为
                    curcamaction.OnStart();
                }
                else
                {
                    //标识相机已经到了最后一个状态, 不做任何操作.
                }
            }
            else
            {
                Debug.LogError("Logic Error");
            }
        }

        void SLGFollow()
        {
            //switch (cammovedir)
            //{
            //    case eCamMoveDir.CamMove_Right:
            //        {
            //            if (Owner.ActorTrans.transform.position.x > m_vMiddlePoint.x)
            //            {

            //                if (Owner.PlayerMgr.VInputMove.x < 0f)
            //                {
            //                    transform.forward = Vector3.Lerp(transform.forward, Owner.ActorTrans.right, 10 * Time.deltaTime);
            //                }
            //                else
            //                {
            //                    transform.forward = Vector3.Lerp(transform.forward, Quaternion.Euler(0f, 180f, 0f) * Owner.ActorTrans.right, 10 * Time.deltaTime);
            //                }

            //                Vector3 target = Owner.ActorTrans.transform.position + (transform.forward * (-10) + Vector3.up * 3);
            //                transform.position = Vector3.Lerp(transform.position, target, 10 * Time.deltaTime);

            //            }
            //            break;
            //        }
            //    case eCamMoveDir.CamMove_Left:
            //        {
            //            if (Owner.ActorTrans.transform.position.x < m_vMiddlePoint.x)
            //            {
            //                transform.Translate(Vector3.left * SMoveSpeed * Time.deltaTime, Space.World);
            //            }
            //            break;
            //        }
            //    case eCamMoveDir.CamMove_Up:
            //        {
            //            if (Owner.ActorTrans.transform.position.y > m_vMiddlePoint.y)
            //            {
            //                transform.Translate(Vector3.up * SUpSpeed * Time.deltaTime, Space.World);
            //            }
            //            break;
            //        }
            //}
        }

        #endregion

        #region 系统接口 外部接口
        void Awake()
        {
            //m_fHalfFOVRad = Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad;

            //m_fAspect = Camera.main.aspect;

            //height = m_fCamDis * Mathf.Tan(m_fHalfFOVRad);

            //width = height * m_fAspect;

            //vLastPos = transform.position;

            //vLastRot = transform.rotation.eulerAngles;

            InitializeCamStates();
        }
  
        void OnDisable()
        {
            ClearAllData();
        }

        public void OnStart(BaseActor _owner)
        {

            owner = _owner;

            BeginCurCamAction();

            //SMoveSpeed = owner.BaseAtt.RoleInfo.RoleMoveSpeed;

            //CamMoveDir = BirthMoveDir;

            //m_tTarget = owner.ActorTrans.transform;                                                                                                                                                                                //确定目标

            //BRefreshCameraData = true;

            //CamState = CamBirthState;
        }
        #endregion

}
