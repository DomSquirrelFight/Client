using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.Action
{
    public class SlgFollowCameraAction : CameraBaseAction
    {
        protected override void Reset()
        {
            base.Reset();
            SelfState = eCameStates.eCam_SLGFollow;
            
        }

        public override void Update()
        {
            //计时已经结束
            if (m_bSend)
            {
                if (SelfState == eCameStates.eCam_SLGFollow)
                {
                    DetectTransformChange();    //检测相机数据是否需要更新

                    SlgFollow();                           //处理跟随数据

                    ResetCameraData();              //复位刷新相机状态
                }

            }
            base.Update();
        }

        void SlgFollow()
        {
            //如果判定主角过了相机中点，那么相机就要跟随主角。

            //扩展相机编辑器，绘制相机视野的中点坐标。
        }

      


        

    }


       

}

