using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT.Assets.CameraController.AttTypeDefine {

    public struct sCamTargetPlane
    {
        public Vector3 vPlaneNormal;
        public Vector3 vPlaneTangent;
        public Vector3 vPlanePoint;

        //public void Init(Vector3 pos)
        //{
        //    vPlanePoint = pos;
        //}

    }

    public enum eCamFourCorner
    {
        CamCorner_UpperLeft,
        CamCorner_UpperRight,
        CamCorner_DownLeft,
        CamCorner_DownRight,
    }


}

