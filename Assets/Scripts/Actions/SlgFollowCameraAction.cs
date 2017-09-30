using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
namespace Assets.Scripts.Action
{
    public class SlgFollowCameraAction : CameraBaseAction
    {
        void Reset()
        {
            SelfState = eCameStates.eCam_SLGFollow;
            CountTimeType = eCoutTimeType.CountType_Condition;
        }
    }
}

