using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

[RequireComponent(typeof(BoxCollider)), RequireComponent(typeof(Rigidbody))]
public class CameraWallEvent : MonoBehaviour {

    void Reset()
    {
        BoxCollider bc = gameObject.GetComponent<BoxCollider>();
        bc.isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

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
    }

}
