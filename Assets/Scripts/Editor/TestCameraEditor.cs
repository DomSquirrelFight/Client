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

    
}
