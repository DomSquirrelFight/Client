using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DT.Assets.CameraController;
[CustomEditor(typeof(TestCamera))]
public class TestCameraEditor : Editor {

    TestCamera tc;

    void OnEnable()
    {
        tc = target as TestCamera;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    void OnSceneGUI()
    {
        
        //先计算相机和目标平面的四个交点坐标

        //显示四个交点坐标

        if (tc.m_tTarget)
        {
            if(Handles.Button(tc.m_vPoints[0], Quaternion.identity, 0.5f, 1f, Handles.DotHandleCap))
            {

            }
        }



    }


}
