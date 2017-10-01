using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Action;
using AttTypeDefine;
public class RpgFollowCameraAction : CameraBaseAction {

    public Vector3 OffSet;

    public Vector3 Direction;


    protected override void Reset()
    {
        base.Reset();
        SelfState = eCameStates.eCam_RPGFollow;
    }

    protected override void Update()
    {
        if (m_bIsClosed == true)
            return;

        //计时已经结束
        if (m_bSend)
        {
            if (SelfState == eCameStates.eCam_RPGFollow)
            {
                RpgFollow();                           //处理跟随数据
            }

        }
        base.Update();
    }

    void RpgFollow()
    {
        Vector3 pos = Owner.ActorTrans.position + OffSet;

        tCamera.position = Vector3.Lerp(tCamera.position, pos, fMoveSpeed*Time.deltaTime);

        tCamera.rotation = Quaternion.Lerp(tCamera.rotation, Quaternion.Euler(Direction), fRotSpeed*Time.deltaTime);
    }

}
