using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.Action
{
    public class CameraBaseAction : BaseAction
    {
        #region 变量

        public float fMoveSpeed;

        public float fRotSpeed;

        public eCameStates SelfState;                           //标识自身的相机行为

        protected CameraController CamCtrl;                //相机管理器

        protected int StateIndex;                                   //当前的状态序号

        protected NotifyCamContrl DelNotifyCamContrl_StateOver;         //通知相机管理器当前状态已经结束

        protected virtual void Reset()
        {
            CountTimeType = eCoutTimeType.CountType_Condition;
        }

        public void InitStateData(CameraController cam, int index, NotifyCamContrl _del)                    //初始化相机的所有基础数据
        {
            CamCtrl = cam;
            StateIndex = index;
            DelNotifyCamContrl_StateOver = _del;
        }

        protected virtual void DoBeforeLeavingState() {
            DelNotifyCamContrl_StateOver(StateIndex);
        }

        #endregion

    }
}

