using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class CameraWallEvent : MonoBehaviour {

    //public eCameEventType m_eCamEventType = eCameEventType.CamEvent_ChangeDir;
    public eCamMoveDir m_eCamMoveDir = eCamMoveDir.CamMove_Right;

    void OnTriggerEnter(Collider other)
    {

        //如果触发到的是相机
        if (other.gameObject.tag == "MainCamera")
        {
            //根据当前的运动朝向，阻挡指定的运动轨迹
            CameraController cc = other.gameObject.GetComponent<CameraController>();
            if (null == cc)
            {
                Debug.LogError("Fail to find CameraController");
                return;
            }
            //设置新的运动方向
            cc.CamMoveDir = m_eCamMoveDir;
            //cc.CalculateCamera();
            switch (m_eCamMoveDir)
            {
                case eCamMoveDir.CamMove_Left:
                    {
                        cc.GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Right, cc.ZLineLength);
                        break;
                    }
                case eCamMoveDir.CamMove_Right:
                    {
                        cc.GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Left, cc.ZLineLength);
                        break;
                    }
            }
        }

        //switch (m_eCamEventType)
        //{
        //    case eCameEventType.CamEvent_ChangeDir:
        //        {
                  

        //            break;
        //        }
        //}     
    }
}
