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

        }
    }

}