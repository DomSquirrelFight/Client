using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DT.Assets.CameraController.AttTypeDefine;
using System.Linq;
namespace DT.Assets.CameraController
{
    public class TestCamera : MonoBehaviour
    {
        #region 变量
        public Vector3 TargetPlaneNormal;

        [HideInInspector]
        public Transform m_tTarget;                                                                                                                                                                                //目标对象

        public Vector3[] m_vPoints = new Vector3[4];                                                                                                                                           //相机和目标平面的四个交点坐标
        [HideInInspector]
        public Dictionary<eCamFourCorner, Vector3> m_dCamDir = new Dictionary<eCamFourCorner, Vector3>();                                                      //相机视野四个角的方向向量

        [HideInInspector]
        public Dictionary<eTargetFourCorner, Vector3> m_dTargetCornerPoints = new Dictionary<eTargetFourCorner, Vector3>();                                   //目标视野边界顶点坐标                             
                                                                                                                                           
        float m_fCamDis = 0.5f;                                                                                                                                                                             //设定距离相机的距离<帮助确定四个方向的向量>

        float m_fHalfFOVRad;                                                                                                                                                                                //相机角度一半的弧度值

        float m_fAspect;                                                                                                                                                                                        //相机的宽高比
        #endregion

        void Awake()
        {
            m_fHalfFOVRad = Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad;

            m_fAspect = Camera.main.aspect;

        }

        public void OnStart(Transform _target)
        {
            m_tTarget = _target;                                                                                                                                                                                //确定目标

            RefreshCamTargetBorderPoint();

        }

        public void RefreshCamTargetBorderPoint()                                                                                                                                        //刷新相机到目标平面四个交点坐标, 目标自身边界顶点
        {
            CalCamFourDir();

            for (eCamFourCorner type = eCamFourCorner.CamCorner_UpperLeft; type < eCamFourCorner.CamCorner_Size; type++)
            {
                m_vPoints[(int)type] = CalBordPoint(type);
            }

            //Target Left
            Vector3 tmp = new Vector3(m_vPoints[0].x, m_tTarget.position.y, m_tTarget.position.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Left, tmp);

            //Target Right, 
            tmp = new Vector3(m_vPoints[1].x, m_tTarget.position.y, m_tTarget.position.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Right, tmp);
            
            //Target Up
            tmp = new Vector3(m_tTarget.position.x,m_vPoints[1].y, m_tTarget.position.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Up, tmp);

            //Target Down
            tmp = new Vector3(m_tTarget.position.x, m_vPoints[2].y, m_tTarget.position.z);
            CalculateTargetCorner(eTargetFourCorner.TargetCorner_Down, tmp);
        }                                                                                                                                                

        void CalculateCornerDir(eCamFourCorner type, Vector3 pos)
        {
            if (!m_dCamDir.ContainsKey(type))
                m_dCamDir.Add(type, pos);
            else
                m_dCamDir[type] = pos;
        }

        void CalculateTargetCorner(eTargetFourCorner type, Vector3 pos)
        {
            if (!m_dTargetCornerPoints.ContainsKey(type))
                m_dTargetCornerPoints.Add(type, pos);
            else
                m_dTargetCornerPoints[type] = pos;
        }

        void CalCamFourDir()                                                                                                                                                                            //确定相机的四个视野的方向向量.                                                                                                                               
        {

            float height = m_fCamDis * Mathf.Tan(m_fHalfFOVRad);
            float width = height * m_fAspect;

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

        void CalTargetFourCorner()                                                                                                                                                                  //计算目标4个corner坐标 
        {

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


        private Vector3[] GetValues(Dictionary<eCamFourCorner, Vector3> tmp)
        {
            Vector3[] values = Enumerable.Select(from i in tmp select i,
                   value => GetValue(value)).ToArray();
            return values;
        }

        private Vector3 GetValue(KeyValuePair<eCamFourCorner, Vector3> i)
        {
            return i.Value;
        } 

    }
}

