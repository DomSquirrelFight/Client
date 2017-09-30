using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.Action
{
    public class CameraBaseAction : BaseAction
    {
        #region 变量

        public eCameStates SelfState;

        protected CameraController CamCtrl;                //相机管理器

        protected int StateIndex;                                   //当前的状态序号

        protected NotifyCamContrl DelNotifyCamContrl_StateOver;         //通知相机管理器当前状态已经结束

        public void InitStateData(CameraController cam, int index, NotifyCamContrl _del)                    //初始化相机的所有基础数据
        {
            CamCtrl = cam;
            StateIndex = index;
            DelNotifyCamContrl_StateOver = _del;
        }

        #endregion

    }
}

