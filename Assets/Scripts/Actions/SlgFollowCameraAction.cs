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
    }
}

