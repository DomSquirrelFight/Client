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

            //计算， 绘制相机围绕Y轴旋转的中点坐标，左边框坐标和右边框坐标
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

            #region 绘制相机左边框和有边框线段
            Handles.color = Color.red;
            Vector3 vCamMiddlePoint = cc.GetCameraMajorMiddlePoint();
            Vector3 vLeft = cc.GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Left, cc.ZLineLength);
            Vector3 vRight = cc.GetCameraMajorBorderPoint(eCameraBorderSide.CameraSide_Right, cc.ZLineLength);

            Handles.DrawLine(camMajorHeight, vLeft);//绘制相机到leftpoint.
            Handles.DrawLine(camMajorHeight, vRight);//绘制相机到rightPoint.

            //绘制主角线段
            Handles.color = Color.white;
            Handles.DrawLine(vLeft, vRight);
            #endregion


            //计算， 绘制相机围绕X轴旋转的中点坐标，上边框坐标和下边框坐标
            #region 绘制一个三角形，从相机到主角的YZ平面.
            //note : 如果相机没有围绕X轴旋转，即Ѳ == 0f,那么0点和3点将是重合的

            Handles.color = Color.green;   
           
            Handles.DrawLine(cc.transform.position, vCamMiddlePoint);

            Handles.color = Color.white;
            Vector3 vThirdPoint = new Vector3(vCamMiddlePoint.x, cc.transform.position.y, cc.Owner.ActorTrans.position.z);                                       //相机在主角YZ平面的交点<ThirdPoint>
            Handles.DrawLine(cc.transform.position, vThirdPoint);


            if (vThirdPoint.y != vCamMiddlePoint.y)
            {
                Handles.DrawLine(vCamMiddlePoint, vThirdPoint);
            }
            #endregion

            #region 绘制1点和2点

            #endregion

            #region //Handles.DrawSolidRectangleWithOutline 绘制一个半透明的平面， 需要四个点，1点， 2点。

            #endregion
        }
    }

}