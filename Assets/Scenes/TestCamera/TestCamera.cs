using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DT.Assets.CameraController.AttTypeDefine;

namespace DT.Assets.CameraController
{
    public class TestCamera : MonoBehaviour
    {
        public Vector3 TargetPlaneNormal;

        sCamTargetPlane m_sTargetPlaneInfos;                      //计算保存目标平面的法向量

        Transform m_tTarget;                                                            //目标对象

        [SerializeField]
        private Vector3[] vPoints = new Vector3[4];                                                              //相机和目标平面的四个交点坐标

        void Reset()
        {
            //实例化四个点坐标空间
            //vPoints = 
        }

        public void OnStart(Transform _target)
        {
            m_tTarget = _target;                        //确定目标

            m_sTargetPlaneInfos.vPlanePoint = m_tTarget.position;       //确定目标位置
            m_sTargetPlaneInfos.vPlaneNormal = TargetPlaneNormal;   //确定目标平面法向量
        }



    }
}

