using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.Action
{
    public class CameraBaseAction : BaseAction
    {
        #region 变量

        public float fMoveSpeed;                                  //平移速度

        public float fRotSpeed;                                     //旋转速度

        public eCameStates SelfState;                           //标识自身的相机行为

        protected CameraController CamCtrl;                //相机管理器

        protected int StateIndex;                                   //当前的状态序号

        protected NotifyCamContrl DelNotifyCamContrl_StateOver;         //通知相机管理器当前状态已经结束

        BaseActor Owner;

        #endregion

        #region 通用接口Reset, InitStateData, OnStart, DoBeforeLeavingState
        protected virtual void Reset()
        {
            CountTimeType = eCoutTimeType.CountType_Condition;
        }

        public void InitStateData(BaseActor owner, CameraController cam, int index, NotifyCamContrl _del)                    //初始化相机的所有基础数据
        {
            CamCtrl = cam;      
            StateIndex = index;
            DelNotifyCamContrl_StateOver = _del;
            Owner = owner;
        }

        public override void OnStart()
        {
            tTarget = Owner.ActorTrans;
            tCamera = CamCtrl.CamInstTrans;
            base.OnStart();
        }

        protected virtual void DoBeforeLeavingState() {
            DelNotifyCamContrl_StateOver(StateIndex);
        }
        #endregion

        #region 计算相机中点，相机corner坐标
        Transform tTarget;
        Transform tCamera;
        Vector3 vLastPos;
        Vector3 vLastRot;
        protected bool BRefreshCameraData = true;                                                                           //初始化刷新相机数据状态 ： true
        Vector3 middlePoint;
        public Vector3 MiddlePoint
        {
            get
            {
                return middlePoint;
            }
        }
        protected void DetectTransformChange()
        {
            if (vLastPos != transform.position || vLastRot != transform.rotation.eulerAngles)
            {
                BRefreshCameraData = true;                  //改变了相机的位置或者旋转
            }
            if (BRefreshCameraData)
                    RefreshCameraData();
            vLastPos = transform.position;
            vLastRot = transform.rotation.eulerAngles;
        }                                                                                                                                                        //检测相机的位置或者旋转是否发生了变化，如果发生变化，重新计算所有数据

        Vector3 CalMiddleAtTargetPlane()                                                                                                                                                        //计算相机朝向和目标平面的交点坐标.
        {
            float t = (tTarget.position.z - tCamera.position.z) / tCamera.forward.z;
            middlePoint = tCamera.position + t * tCamera.forward;
            return middlePoint;
        }

        protected void RefreshCameraData()
        {
            CalMiddleAtTargetPlane();
        }

        protected void ResetCameraData()
        {
            BRefreshCameraData = false;
        }
//        public void RefreshCamTargetBorderPoint()                                                                                                                                        //刷新相机到目标平面四个交点坐标, 目标自身边界顶点
//        {
//            if (!m_bRefreshCameraData)  //如果m_bRefreshCameraData = false，则不开启刷新相机数据
//                return;
//#if UNITY_EDITOR
//            CalCamFourDir();
//            for (eCamFourCorner type = eCamFourCorner.CamCorner_UpperLeft; type < eCamFourCorner.CamCorner_Size; type++)
//            {
//                m_vPoints[(int)type] = CalBordPoint(type);
//            }
//#endif
//            //calculate middle point
//            CalMiddleAtTargetPlane();
//            //calculate target's border coordinates.
//            CalTargetFourCorner();
//            m_bRefreshCameraData = false; //处理完相机数据，关闭处理相机数据开关
//        }

//        void CalTargetFourCorner()                                                                                                                                                                  //计算目标4个corner坐标
//        {
//            Vector3 tmp;
//            //Target Left
//            tmp = transform.position - transform.right * width;
//            //tmp += transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            tmp = GetTargetCornerPoint(tmp);
//            //tmp = new Vector3(tmp.x, m_tTarget.position.y, tmp.z);
//            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Left, tmp);
//            //Target Right,
//            tmp = transform.position + transform.right * width;
//            //tmp += transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            tmp = GetTargetCornerPoint(tmp);
//            // tmp = new Vector3(tmp.x, m_tTarget.position.y, tmp.z);
//            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Right, tmp);
//            //Target Up
//            //tmp = transform.position + transform.right * width;
//            tmp = transform.position;
//            tmp += transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            tmp = GetTargetCornerPoint(tmp);
//            //tmp = new Vector3(m_tTarget.position.x, tmp.y, tmp.z);
//            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Up, tmp);
//            //Target Down
//            tmp = transform.position;
//            tmp -= transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            tmp = GetTargetCornerPoint(tmp);
//            //tmp = new Vector3(m_tTarget.position.x, tmp.y, tmp.z);
//            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Down, tmp);
//        }

//        void CalculateTargetCorner(eTargetFourCorner type, Vector3 pos)
//        {
//            if (!m_dTargetCornerPoints.ContainsKey(type))
//                m_dTargetCornerPoints.Add(type, pos);
//            else
//                m_dTargetCornerPoints[type] = pos;
//        }

//        Vector3 GetTargetCornerPoint(Vector3 dir)
//        {
//            float t = (m_tTarget.position.z - transform.position.z) / dir.z;
//            Vector3 corner = transform.position + t * dir;
//            return corner;
//        }
//        void CalCamFourDir()                                                                                                                                                                               //确定相机的四个视野方
//        {
//            Vector3 tmp;
//            //UpperLeft
//            tmp = transform.position - transform.right * width;
//            tmp += transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            CalculateCornerDir(eCamFourCorner.CamCorner_UpperLeft, tmp);
//            //UpdateRight
//            tmp = transform.position + transform.right * width;
//            tmp += transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            CalculateCornerDir(eCamFourCorner.CamCorner_UpperRight, tmp);
//            //DownLeft
//            tmp = transform.position - transform.right * width;
//            tmp -= transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            CalculateCornerDir(eCamFourCorner.CamCorner_DownLeft, tmp);
//            //DownRight
//            tmp = transform.position + transform.right * width;
//            tmp -= transform.up * height;
//            tmp += transform.forward * m_fCamDis;
//            tmp = (tmp - transform.position).normalized;
//            CalculateCornerDir(eCamFourCorner.CamCorner_DownRight, tmp);
//        }
//        Vector3 CalBordPoint(eCamFourCorner type)                                                                                                                                        //计算相机指定距离视野边界顶点坐标
//        {
//            float t = 0f;
//            //相机视野UpperLeft在目标平面的交点坐标
//            //Vector3 vTargetPlaneInterPoint = transform.position + t * m_dCamDir[type];
//            //目标平面向量
//            //Vector3 vTargetPlane = vTargetPlaneInterPoint - m_tTarget.position;
//            // (0, 0, -1) dot (vTargetPlane) = 0;
//            //(vTargetPlaneInterPoint - m_tTarget.position).z * (-1) = 0
//            //vTargetPlaneInterPoint.z = m_tTarget.position.z
//            //(transform.position + t * m_dCamDir[eCamFourCorner.CamCorner_UpperLeft]).z = m_tTarget.position.z
//            t = (m_tTarget.position.z - transform.position.z) / m_dCamDir[type].z;
//            Vector3 corner = transform.position + t * m_dCamDir[type];
//            return corner;
//        }
//        void CalculateCornerDir(eCamFourCorner type, Vector3 pos)
//        {
//            if (!m_dCamDir.ContainsKey(type))
//                m_dCamDir.Add(type, pos);
//            else
//                m_dCamDir[type] = pos;
//        }


        #endregion    
    }
}

