using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[CustomEditor(typeof(CameraController))]
public class CameraControllerEditor : Editor {

    CameraController cc;

    private void OnEnable()
    {
        cc = target as CameraController;
    }

    private void OnSceneGUI()
    {
        //获取当前相机围绕Y轴旋转的角度
        Handles.color = Color.red;
        if (cc.Owner)
        {
            //和主角高度一致的相机位置坐标
            Vector3 camMajorHeight = new Vector3(
                   cc.transform.position.x,
                   cc.Owner.ActorTrans.position.y,
                   cc.transform.position.z);

            Handles.color = Color.white;

            #region 绘制一个三角形

            //绘制一条直线，从相机，垂直向上一条先发射
            Handles.DrawLine(new Vector3(
                    cc.transform.position.x,
                    cc.Owner.ActorTrans.position.y,
                       cc.transform.position.z),
                    new Vector3(
                         cc.transform.position.x,
                         cc.Owner.ActorTrans.position.y,
                         cc.Owner.ActorTrans.position.z
                        )
                );

            Handles.DrawLine(cc.transform.position,
                 new Vector3(
                         cc.transform.position.x,
                         cc.Owner.ActorTrans.position.y,
                         cc.Owner.ActorTrans.position.z
                        )
                );

            Handles.DrawLine(
               cc.transform.position,
               new Vector3(
                   cc.transform.position.x,
                   cc.Owner.ActorTrans.position.y,
                   cc.transform.position.z
                   )
                );

            #endregion

            #region 绘制相机到主角线段的线段
            #region 经过测试，结果错误
            ////2.1.2 获取相机的旋转角度
            //float fDegreeCamToMajor = cc.transform.rotation.y;
            ////2.1.3 获取相机射线长度
            //float fZLineLength = fZCamToMajor / Mathf.Cos(fDegreeCamToMajor);
            #endregion
            
            Handles.color = Color.red;
            Vector3 vCamMiddlePoint = cc.GetCameraMajorMiddlePoint();
            Handles.DrawLine(
                    camMajorHeight,
                    vCamMiddlePoint
                );
            #endregion

            #region 绘制相机左边框和有边框线段
            Vector3 vLeft = cc.GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Left, cc.ZLineLength);
            Vector3 vRight = cc.GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Right, cc.ZLineLength);

            Handles.DrawLine(camMajorHeight, vLeft);//绘制相机到leftpoint.
            Handles.DrawLine(camMajorHeight, vRight);//绘制相机到rightPoint.

            //绘制主角线段
            Handles.color = Color.white;
            Handles.DrawLine(vLeft, vRight);
            #endregion
            
        }
    }

}